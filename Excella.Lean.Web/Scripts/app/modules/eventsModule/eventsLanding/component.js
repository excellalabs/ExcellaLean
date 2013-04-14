define(['Boiler', './eventsLandingViewModel', 'text!./eventsLandingView.html', 'text!./eventsLandingStyles.css'], function (Boiler, ViewModel, template, styleText) {

	var Component = function(moduleContext) {

		var vm, panel = null;

	    this.activate = function(parent, params) {
	        if (!panel) {
	            panel = new Boiler.ViewTemplate(parent, template, null, styleText);
	            vm = new ViewModel(moduleContext);
	            ko.applyBindings(vm, panel.getDomElement());
	        }

	        vm.activate(params);
	        panel.show();

	    };

	    this.deactivate = function() {
	        if (panel) {
	            panel.hide();
	        }

	    };

	};

	return Component;

}); 