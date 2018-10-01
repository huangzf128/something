$(function() {
    var grps = [];
    var grp_tabs = {};
    
    getStorage().then((data) => {

        grps = getGroup(data);
        grp_tabs = getGrpTabMapping(data);

        // alert(JSON.stringify(grp_tabs));

        var tabList = document.querySelector("#tab-list");

        var tabHtml = "";
        var i = 0;
        for (var tabs in grp_tabs) {
            tabHtml = tabHtml + " <div class='draggable'> \
                                    {nav-bar} \
                                    <ul class='uk-sortable' data-uk-sortable=\"{group:'my-group', dragCustomClass:\'uk-panel-box\'}\">";
            for(var tab of grp_tabs[tabs]) {
                tabHtml = tabHtml + "<li class='uk-panel-box' id='" + (i++) +"'> \
                                            <a target='_blank' href=" + tab.url + ">" + tab.title + "</a></li>";
            }
            tabHtml = tabHtml + "</ul></div> <br/><br/>";
        }

        tabHtml = tabHtml.replace(/\{nav-bar\}/g, $("#nav-bar-copy")[0].innerHTML);
        tabList.innerHTML = tabHtml;

        draggableHandler();

    }, onError);

    $('[data-uk-sortable]').on("change.uk.sortable", function(e, item, dragged){
        //alert(item);
        //alert(JSON.stringify(item));
        //e.stopPropagation();
    });

}());


var draggableHandler = function() {

    $(".draggable" ).draggable({
        handle: ".dragging",
        axis: "y",
        start : function() {
            // move to front
            $(this).data("z-index", $(this).css("z-index"));
            $(this).css("z-index", 999);
        },
        stop : function() {
            // reset z position
            $(this).css("z-index", $(this).data("z-index"));
            var currentDiv = this;
            $(".draggable").each(function(index){
                if (currentDiv != this) {
                    isMouseInDiv(this, index);
                }
            });
        }
    });

    registMousePosition();

    function isMouseInDiv(div, index) {
        var divRect = div.getBoundingClientRect();
        if(divRect.top < currentMousePos.y && currentMousePos.y <divRect.bottom) {
            alert(index);
        }
    }

    function registMousePosition () {
        $(document).mousemove(function(event) {
            currentMousePos.x = event.pageX;
            currentMousePos.y = event.pageY;
        });
    }
    
    this.currentMousePos = { x: -1, y: -1 };
}


function getStorage() {
    return browser.storage.sync.get();
}

function getGroup(data) {
    return data[config.storage_group_key];
}

function getGrpTabMapping (data) {
    var gs = getGroup(data);
    var g_ts = {};
    for (var gCd in gs) {
        var tab_key = getStorageTabKey(gCd);
        g_ts[tab_key] = data[tab_key];
    }
    return g_ts;
}



/* ----- trach code for study ------ */

// browser.runtime.onMessage.addListener(request => {
//     console.log(request.greeting);
//     return Promise.resolve({response: "Hi from content script"});
// });