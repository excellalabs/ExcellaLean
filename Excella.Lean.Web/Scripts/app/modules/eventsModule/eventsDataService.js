define(['jquery', 'breeze', 'q', 'toastr', 'logger', './eventsModel'], function ($, breeze, q, toastr, logger, model) {
    var initialized = false;
    
    var serviceName = "api/Events";
    var reqServiceName = "api/Request";
       
    var dataService = new breeze.DataService({
        serviceName: serviceName
        //hasServerMetadata: false // don't ask the server for metadata
    });

    var core = breeze.core,
        entityModel = breeze.entityModel,
        entityQuery = entityModel.EntityQuery,
        op = breeze.FilterQueryOp;
    
    // configure Breeze for Knockout and Web API 
    core.config.setProperties({
        trackingImplementation: entityModel.entityTracking_ko,
        remoteAccessImplementation: entityModel.remoteAccess_webApi
    });
    
    entityModel.NamingConvention.none.setAsDefault();

    var metadataStore = new entityModel.MetadataStore();
    
    // manager.enableSaveQueuing(true);
    
    // Now, go configure the metadata store (in the model module).
    // This sets tells Breeze about the client side types.
    // We also tell Breeze to add ko.computeds to them.
    var manager = new breeze.EntityManager({ dataService: dataService, metadataStore: metadataStore });
    
    model.configureMetadataStore(metadataStore);

    // Perhaps, list resources in an Enum
    //var ResourceTypes = { };
    
    function getEvents(eventsObservable) {
        eventsObservable.removeAll();

        var query = entityQuery
            .from("Events");

        manager.executeQuery(query)
            .then(querySucceeded)
            .fail(queryFailed);

        function querySucceeded(data) {
            eventsObservable(data.results);
        }
    }
       
    function getEventById(eventId, eventObservable) {
        var query = entityQuery
            .from("Events")
            .where('Id', op.Equals, eventId);

        manager.executeQuery(query)
            .then(querySucceeded)
            .fail(queryFailed);
        
        function querySucceeded(data) {
            var record = data.results[0];
            eventObservable(record);
        }
    }
    
    function getReservationResultById(reservationResultId, reservationResultObservable) {
        var query = entityQuery
            .from("ReservationResults")
            .where('Id', op.Equals, reservationResultId);

        manager.executeQuery(query)
        .then(querySucceeded)
        .fail(queryFailed);

        function querySucceeded(data) {
            var record = data.results[0];
            reservationResultObservable(record);
        }
    }

    function requestReservation(reservationRequest, reservationResultObservable) {
        var request = JSON.stringify(reservationRequest);
        toastr.info('Processing Reservation');
        
        $.ajax({
            url: reqServiceName + '/RequestReservation',
            type: "POST",
            data: request,
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        })
            .then(success)
            .fail(serviceFailed);

        function success(data) {
            reservationResultObservable(data);
            toastr.success('Reservation has been processed!');
        }
    }

    
    var hasChanges = ko.observable(false); //dataservice 'hasChanges' observable
    manager.hasChangesChanged.subscribe(function (eventArgs) {
        // update the dataservice observable 'hasChanges' 
        // based on the manager's latest 'hasChanges' state.
        hasChanges(eventArgs.hasChanges);
    });

    var cancelChanges = function () {
        manager.rejectChanges();
        toastr.success(app.toasts.canceledData);
    };

    var saveChanges = function () {
        // This could include added, modified and deleted entities.
        manager.saveChanges().then(function (saveResult) {
            toastr.success(app.toasts.savedData);
        }).fail(saveFailed);
    };

    // Internal methods        
    var queryFailed = function (error) {
        logger.logError(error, 'Query failed: ');
    };
    
    var serviceFailed = function (error) {
        logger.logError(error, 'Service failed: ');
    };

    var getAllOfTypeLocally = function (resource, orderBy) {
        //return manager.getEntities(metadataStore.getEntityType(typeName));
        return entityQuery
            .from(resource)
            .using(manager)
            .orderBy(orderBy)
            .executeLocally();
    };

    var saveFailed = function (error) {
        // 'app is not defined' doesn't seem to be a real error
        if (error.message == "app is not defined") {
            toastr.success("Record saved successfully!");
        } else {
            logger.logError(error, 'Save failed: ');
        }
    };

    function mergePartialEntityIntoCache(data, entityName) {
        var entityType = metadataStore.getEntityType(entityName);
        var entityArray = data.results.map(function (dto) {
            var id = dto.id,
                key = new entityModel.EntityKey(entityType, id),
                entity = manager.findEntityByKey(key);
            if (!entity) {
                // We don't have it, so create it
                entity = entityType.createEntity();
                entity.id(id);
                manager.attachEntity(entity);
                // Now I have an entity, with observables, and computeds. No data
                entity.isPartial = true;
            }
            model.mapToEntity(entity, dto);
            entity.entityAspect.setUnchanged();
            return entity;
        });
        return entityArray;
    }

    initialized = true;

    return {
        cancelChanges: cancelChanges,
        hasChanges: hasChanges,
        saveChanges: saveChanges,
        entityManager: manager,
        
        getEvents: getEvents,
        getEventById: getEventById,
        getReservationResultById: getReservationResultById,
        requestReservation: requestReservation
    };
});
