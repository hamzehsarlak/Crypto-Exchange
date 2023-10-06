"use strict";

const listingUri = "api/v1/listings";
const rateUri = "api/v1/rates";
const getAllListingsUri = listingUri + "/getAllListings";
const getAllRatesUri = rateUri + "/getAllRates";
const getAllConversionsUri = listingUri + "/getAllConversions";
let conversions = [];
let listings = [];
let rates = [];

function getAllListings() {
    fetch(getAllListingsUri)
        .then(response =>
            response.json()
        )
        .then(data => {
            listings = data.result;            
        })
        .catch(error => showToast('Unable to get Listings.<br>' + JSON.stringify(error)));
}

function getAllRates() {
    fetch(getAllRatesUri)
        .then(response =>
            response.json()
        )
        .then(data =>
            rates = data.result
        )
        .catch(error => showToast('Unable to get Rates.<br>' + JSON.stringify(error)));
}

function getAllConversions(callback) {
    fetch(getAllConversionsUri)
        .then(response =>
            response.json()
        )
        .then(function (data) {
                if(callback) callback(data);
                return conversions = data;
            }
        )
        .catch(error => showToast('Error', 'Unable to get conversions: ' + JSON.stringify(error),'error'));
}

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/clientHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 10000);
    }
};

connection.onclose(async () => {
    await start();
});

connection.on("conversions", function ( message) {
    showToast('Update', 'Data has been updated','success')
    console.log("Conversions updated");
    updateTable();
});

// Start the connection.
start();

function updateTable(){
    getAllConversions(function (data)
    {
        let dt= $('#dataTable');
        dt.dataTable().fnClearTable();
        dt.dataTable().fnAddData(data);
    });
}
function showToast(heading, text, icon) {
    $.toast({
        heading: heading,
        text: text,
        showHideTransition: 'slide',
        icon: icon
    })
}

$(document).ready(function () {
    
    let dt= $('#dataTable');
    dt.DataTable({
        columns: [
            {data: 'name'},
            {data: 'symbol'},
            {data: 'btcPrice'},
            {data: 'usdPrice'},
            {data: 'conversions.EUR'},
            {data: 'conversions.BRL'},
            {data: 'conversions.GBP'},
            {data: 'conversions.AUD'}
        ]
    });

    updateTable();
});