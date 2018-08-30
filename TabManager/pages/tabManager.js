// browser.runtime.onMessage.addListener(request => {
//     alert("lssss");
//     //alert(JSON.stringify(request.greeting));
//     //return Promise.resolve({response: "Hi from content script"});
//     return {response: "ok"};
// });

function handleMessage(request, sender, sendResponse) {
    alert("Message from the content script: " + request.greeting);
    sendResponse({response: "Response from background script"});
}
  
browser.runtime.onMessage.addListener(handleMessage);