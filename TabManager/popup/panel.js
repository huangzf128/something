// close and save all tabls
var csAllTabBtn = document.querySelector("#cs-alltab");
csAllTabBtn.addEventListener("click", function(e){
    getAllTabs().then((tabs) => {
        var targetTabs = [];
        for (var tab of tabs) {

            if (!tab.url.match('^about:')) {
                targetTabs.push({
                    "id"   : tab.id,
                    "title": tab.title,
                    "url"  : tab.url
                });
            };
        }

        //alert(JSON.stringify(targetTabs));
        var tabObj = {};
        tabObj[config.storage_tab_key] = targetTabs;

        browser.storage.sync.set(tabObj).then(() => {
            alert("saved!!");
        }, onError);
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

// ------ function ----------

function getAllTabs() {
    return browser.tabs.query({});
}

function onError(error) {
    alert(error);
}
