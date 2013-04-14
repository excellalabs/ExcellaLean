define(['Boiler'], function (Boiler) {
    var viewModel = function (moduleContext) {

        var self = this,
            event = ko.observable(),
            activate = function(routeData) {
                moduleContext.dataService.getEventById(parseInt(routeData.id), this.event);
            };

        return {
            activate: activate,
            event: event
        };
    };

    return viewModel;
});
