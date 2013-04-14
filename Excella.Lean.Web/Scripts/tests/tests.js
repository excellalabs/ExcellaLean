require.config({
	baseUrl : "../app/", //we will set the app's src folder as the base url
});

require.config({
	paths : {
		text : './Scripts/lib/require/text',
		i18n : './Scripts/lib/require/i18n',
		domReady : '../Scripts/lib/require/domReady',
		path :  '../Scripts/lib/require/path',
		_boiler_ : './core/_boiler_'
	}
});


require([ 
          '../tests/core/helpers/settings', 
          '../tests/core/helpers/router' ,
          '../tests/core/helpers/mediator',
          '../tests/other/js-encapsulation',
          '../tests/other/js-prototypes'
], function() {}); 
