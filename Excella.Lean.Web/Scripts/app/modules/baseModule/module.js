define(['Boiler', './landingPage/component'], function (Boiler, LandingPageComponent) {

    var Module = function (globalContext) {
        var context = new Boiler.Context(globalContext);

        //scoped DomController that will be effective only on $('#page-content')
        var controller = new Boiler.DomController($('#page-content'));
        //add routes with DOM node selector queries and relevant components
        //controller.addRoutes({
        //    ".footer": new FooterComponent(context)
        //});
        controller.start();

        //the landing page should respond to the root URL, so let's use an URLController too
        var controller = new Boiler.UrlController($(".appcontent"));
        controller.addRoutes({
            "/": new LandingPageComponent()
        });
        controller.start();
    };

    return Module;

});
