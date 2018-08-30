// close and save all tabls
var csAllTabBtn = document.querySelector("#cs-alltab");
csAllTabBtn.addEventListener("click", function(e){
    getAllTabs().then((tabs) => {
        var targetTabs = [];
        for (var tab of tabs) {
            targetTabs.push({
                "id"   : tab.id,
                "title": tab.title,
                "url"  : tab.url
            });
        }
        //alert(JSON.stringify(targetTabs));
        var storingTabs = browser.storage.sync.set({ "tabs" : targetTabs });
        storingTabs.then(() => {
            alert("saved");
        }, onError);
    });
});



// close and save one tab


// show all tab
var showAllTab = document.querySelector("#show-alltab");
showAllTab.addEventListener("click", function(e) {
    var storingTabs = browser.storage.sync.get("tabs");
    storingTabs.then((tabs) => {
        managerTab = browser.tabs.create({
            url:"../pages/tabManager.html"
        });
        
        managerTab.then((newTab) => {
            
            browser.tabs.executeScript({
                code: `browser.runtime.onMessage.addListener(request => {
                    alert("lssss");
                    return {response: "ok"};
                });`
            });

            // browser.tabs.sendMessage(
            //     newTab.id,
            //     {"greeting": "storingTabs"}
            // ).then(response => {
            //     alert("ok");
            // }).catch(onError);

            var sending = browser.runtime.sendMessage({
                greeting: "Greeting from the content script"
            });
            sending.then(handleResponse, handleError);             
        });
        //alert(JSON.stringify(tabs));
    }, onError);
});

function handleResponse(message) {
    console.log(`Message from the background script:  ${message.response}`);
  }
  
  function handleError(error) {
    console.log(`Error: ${error}`);
  }
  
// ------ function ----------

function getAllTabs() {
    return browser.tabs.query({});
}

function onError(error) {
    console.log(error);
    alert(error);
}

function sleep(waitMsec) {
    var startMsec = new Date();
    while (new Date() - startMsec < waitMsec);
}