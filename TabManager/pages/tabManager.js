(function() {
    var grps = [];
    var grp_tabs = {};
    
    getStorage().then((data) => {

        grps = getGroup(data);
        grp_tabs = getGrpTabMapping(data);

        // alert(JSON.stringify(grp_tabs));

        var tabList = document.querySelector("#tab-list");

        var tabHtml = "";
        for (var tabs in grp_tabs) {
            tabHtml = tabHtml + "<li class='uk-nestable-item'><div class='uk-nestable-panel'><ul class='uk-nestable-list'>";

            for(var tab of grp_tabs[tabs]) {
                tabHtml = tabHtml + "<li class='uk-nestable-item'><div class='uk-nestable-panel'><a target='_blank' href=" + tab.url + ">" + tab.title + "</a></div></li>";
            }
            tabHtml = tabHtml + "</ul></div></li>";
        }

        tabList.innerHTML = tabHtml;

    }, onError);
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