
let getPlaces = async () => {

    let dataJ = await fetch("https://localhost:5001/api/Places/", {
        method: "GET"
    });
    return await dataJ.json();
}

getPlaces().then(data => {
    for (const place of data) {
        console.log(place);
        let marker = L.marker([place.latitude, place.longitude]).bindPopup(`<h3>${place.name}</h3><p>${place.description}</p>`).addTo(mymap);
    }

});


const mymap = L.map('mapid').setView([45.4552, -75.7649], 13);
L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token={accessToken}', {
    attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
    id: 'mapbox/streets-v11',
    tileSize: 512,
    zoomOffset: -1,
    accessToken: 'pk.eyJ1Ijoic3RlcGhlbnNvbi1oZXJpdGFnZSIsImEiOiJjanZ4ejlxazMwYWRlNDhrOHJxN2hlZGl5In0.GvwpDRkNHQKPfS8S2SA4Dg'
}).addTo(mymap);

mymap.on('click', (e) => {
    console.log(e.latlng);
});