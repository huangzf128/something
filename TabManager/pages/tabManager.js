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
            tabHtml = tabHtml + "<li class=''> \
                                    <div class=''> \
                                    {nav-bar} \
                                    <ul class='uk-sortable' data-uk-sortable=\"{group:'my-group', dragCustomClass:\'uk-panel-box\'}\">";
            for(var tab of grp_tabs[tabs]) {
                tabHtml = tabHtml + "<li class='uk-panel-box' id='" + (i++) +"'> \
                                            <a target='_blank' href=" + tab.url + ">" + tab.title + "</a></li>";
            }
            tabHtml = tabHtml + "</ul></div></li> <br/><br/>";
        }

        tabHtml = tabHtml.replace(/\{nav-bar\}/g, $("#nav-bar-copy")[0].innerHTML);
        tabList.innerHTML = tabHtml;


    }, onError);

    $('[data-uk-sortable]').on("change.uk.sortable", function(e, item, dragged){
        //alert(item);
        //alert(JSON.stringify(item));
        //e.stopPropagation();
    });    
}());

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