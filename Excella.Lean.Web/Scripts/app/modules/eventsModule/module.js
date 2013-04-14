define(['Boiler', './settings', './eventsDataService', './eventsLanding/component', './eventDetails/component'], function (Boiler, settings, DataService, Landing, EventDetails) {

	var Module = function(globalContext) {

		var context = new Boiler.Context("events", globalContext);
		context.addSettings(settings);
	    
	    context.dataService = DataService;

		var controller = new Boiler.UrlController($(".appcontent"));
		controller.addRoutes( {
		    'events/all': new Landing(context),
		    'events/{id}': new EventDetails(context)
		});
		controller.start();

	};

	return Module;

});
