"use strict";

/** Create Connection using Url Configure in program.cs */
let connection = new signalR.HubConnectionBuilder()
  .withUrl("/messages")
  .build();

/** Connection Configure in hub */
connection.on("ReceiveMessage", function (message) {
  let msg = message
    .replace(/&/g, "&amp;")
    .replace(/</g, "&lt;")
    .replace(/>/g, "&gt;");

  /** add new message to UI */
  let div = document.createElement("div");
  div.innerHTML = msg + "<hr />";
  document.getElementById("messages").appendChild(div);
});

/** Check Error has or not */
connection.start().catch(function (err) {
  return console.error(err.toString());
});

/** Send Button Click Event */
document
  .getElementById("sendButton")
  .addEventListener("click", function (event) {
    let message = document.getElementById("message").value;

    /** invoke message hub connection */
    connection.invoke("SendMessageToAll", message).catch(function (err) {
      return console.error(err.toString());
    });

      document.getElementById('message').value = '';
    event.preventDefault();
  });
