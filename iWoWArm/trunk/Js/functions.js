var Site = {

    load: function() {
        Site.vertical();
        if (navigator.userAgent.indexOf('iPhone') != -1) {
            setTimeout(Site.hideURLbar(), 0);
        }
        window.scrollTo(0, 1);
        new Fx.Scroll(window).toTop();
    },

	vertical: function(){

        var list = $$('#GeneralInfoSections li div.collapse');
		var headings = $$('#GeneralInfoSections li h3');
		var collapsibles = new Array();
		
		headings.each(function(heading, i) {

			var collapsible = new Fx.Slide(list[i], { 
				duration: 300, 
				transition: Fx.Transitions.linear,
				onComplete: function(request){ 
					var open = request.getStyle('margin-top').toInt();
					if(open >= 0) new Fx.Scroll(window).toElement(headings[i]);
				}
			});
			
			collapsibles[i] = collapsible;
			
			heading.onclick = function(){
				var span = $E('span', heading);

				if(span){
					var newHTML = span.innerHTML == '+' ? '-' : '+';
					span.setHTML(newHTML);
				}
				
				collapsible.toggle();
				return false;
			}
			
			collapsible.hide();
			
		});
			
	    /*$('collapse-all').onclick = function(){
		    headings.each( function(heading, i) {
			    collapsibles[i].hide();
			    var span = $E('span', heading);
			    if(span) span.setHTML('+');
		    });
		    return false;
	    }
    	
	    $('expand-all').onclick = function(){
		    headings.each( function(heading, i) {
			    collapsibles[i].show();
			    var span = $E('span', heading);
			    if(span) span.setHTML('-');
		    });
		    return false;
	    }*/
	}, 
	
	hideURLbar: function() {
        window.scrollTo(0, 1);
    }
};

window.addEvent('domready', Site.load);


  /*  toggle: function(elementId) {
    
    }
function toggleElement(elementId) {
    var slider = new Fx.Slide(elementId);
    slider.toggle();
    return false;
}


function hideURLbar() {
        window.scrollTo(0, 1);
}

} */