// close and save all tabls
var csAllTabBtn = document.querySelector("#cs-alltab");
csAllTabBtn.addEventListener("click", function(e) {

    var grps = null;
    getGroupFromStorage()
    .then((g) => {

        grps = g[config.storage_group_key] || [];
        return getAllTabs();
    })
    .then((tabs) => {
        var targetTabs = [];
        var grpCd = getNewGroupCode(grps);

        for (var tab of tabs) {

            if (!tab.url.match('^about:')) {
                targetTabs.push({
                    "id"   : tab.id,
                    "title": tab.title,
                    "url"  : tab.url
                });
            };
        }

        setToStorage([config.storage_group_key, getStorageTabKey(grpCd)], 
                     [grps, targetTabs]);

        //alert(JSON.stringify(targetTabs));
        // var tabObj = {};
        // tabObj[getStorageTabKey(grpCd)] = targetTabs;

        // browser.storage.sync.set(tabObj).then(() => {
        //     alert("saved!!");
        // }, onError);
    });
});

// close and save one tab

// show all tab
var showAllTab = document.querySelector("#show-alltab");
showAllTab.addEventListener("click", function(e) {
    
    browser.tabs.create({
        url:"../pages/tabManager.html"
    })

    // browser.storage.sync.get("tabs").then((tabs) => {
    //     browser.tabs.create({
    //         url:"../pages/tabManager.html"
    //     }).then((newTab) => {
            
    //         browser.tabs.executeScript({
    //             //code: `alert("123");`
    //             file: "../pages/tabManager.js"
    //         });

    //         browser.tabs.onUpdated.addListener(function(tabId, changeInfo, tabInfo){
    //             // important 
    //             if (changeInfo.status == "complete") {
    //                 browser.tabs.sendMessage(
    //                     newTab.id,
    //                     {"greeting": "storingTabs"}
    //                 ).then(response => {
    //                     alert(response.response);
    //                 }).catch(onError);
    //             }
    //         });

    //     });
    //     //alert(JSON.stringify(tabs));
    // }, onError);
});

var showAllTab = document.querySelector("#cs-onetab");
showAllTab.addEventListener("click", function(e) {
    browser.storage.sync.clear();
});

// ------ function ----------

function getGroupFromStorage() {
    return browser.storage.sync.get(config.storage_group_key);
}

function getNewGroupCode(grps) {
    var cnt = grps.length;
    for(var i = 0; i < cnt; i++) {
        if (grps.indexOf(i) == -1) {
            grps.push(i);
            return i;
        }
    }
    grps.push(cnt);
    return cnt;
}


function getAllTabs() {
    return browser.tabs.query({});
}

