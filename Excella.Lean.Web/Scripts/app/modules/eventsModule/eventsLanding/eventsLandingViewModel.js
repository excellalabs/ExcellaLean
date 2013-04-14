define(['Boiler'], function (Boiler) {
	var viewModel = function(moduleContext) {

	    var self = this,
		events = ko.observableArray(),
	    eventClicked = function (event) {
	        Boiler.UrlController.goTo("events/" + event.Id);
	    },
	    activate = function (routeData) {
	        moduleContext.dataService.getEvents(this.events);
	    };
	    
	    return {
	        activate: activate,
	        events: events,
	        eventClicked: eventClicked
		};
	};

    return viewModel;
});
