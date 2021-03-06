(function () {
    var tileUrl = 'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png';
    var tileAttribution = 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>';

    let currentLatitude;
    let currentLongitude;

    // Global export
    window.deliveryMap = {
        showOrUpdate: function (elementId, markers, markerSelector, plotRoute) {
            var elem = document.getElementById(elementId);
            if (!elem) {
                throw new Error('No element with ID ' + elementId);
            }

            // Initialize map if needed
            if (!elem.map) {
                elem.map = L.map(elementId);
                elem.map.addedMarkers = [];
                L.tileLayer(tileUrl, { attribution: tileAttribution }).addTo(elem.map);
            }

            var map = elem.map;
            if (map.addedMarkers.length !== markers.length) {
                // Markers have changed, so reset
                map.addedMarkers.forEach(marker => marker.removeFrom(map));
                map.addedMarkers = markers.map(m => {
                    return L.marker([m.y, m.x]).bindPopup(m.description).addTo(map);
                });

                // Auto-fit the view
                var markersGroup = new L.featureGroup(map.addedMarkers);
                map.fitBounds(markersGroup.getBounds().pad(0.3));

                // Show applicable popups. Can't do this until after the view was auto-fitted.
                markers.forEach((marker, index) => {
                    if (marker.showPopup) {
                        map.addedMarkers[index].openPopup();
                    }
                });
            } else {
                // Same number of markers, so update positions/text without changing view bounds
                markers.forEach((marker, index) => {
                    animateMarkerMove(
                        map.addedMarkers[index].setPopupContent(marker.description),
                        marker,
                        4000);
                });
            }

            // selecting point on map
            if (markerSelector === true) {
                var theMarker = {};

                map.on('click', function (e) {
                    lat = e.latlng.lat;
                    lon = e.latlng.lng;

                    if (theMarker != undefined) {
                        map.removeLayer(theMarker);
                    };

                    theMarker = L.marker([lat, lon]).addTo(map);

                    currentLatitude = lat;
                    currentLongitude = lon;
                });

            }

            // join up the markers
            if (plotRoute === true) {

                function onEachDot(feature, layer) {
                    layer.bindPopup('<table style="width:180px"><tbody><tr><td><div><b>name:</b></div></td><td><div>'
                        + feature.properties.popup +
                        '</div></td></tr><tr class><td><div><b>time:</b></div></td><td><div>'
                        + feature.properties.time +
                        '</div></td></tr></tbody></table>');

                    spiralLayer = L.geoJson(markers, {
                        onEachFeature: onEachDot
                    });

                    spiralBounds = spiralLayer.getBounds();
                    map.fitBounds(spiralBounds);
                    spiralLayer.addTo(map);

                    function connectTheDots(data) {
                        var c = [];
                        for (i in data._layers) {
                            var x = data._layers[i]._latlng.lat;
                            var y = data._layers[i]._latlng.lng;
                            c.push([x, y]);
                        }
                        return c;
                    }

                    spiralCoords = connectTheDots(spiralLayer);
                    var spiralLine = L.polyline(spiralCoords).addTo(map)
                }
            }

        },

        // selecting point on map
        getCurrentMarkerLocation: function () {
            return `${currentLatitude} ${currentLongitude}`;
        }

    };

    function animateMarkerMove(marker, coords, durationMs) {
        if (marker.existingAnimation) {
            cancelAnimationFrame(marker.existingAnimation.callbackHandle);
        }

        marker.existingAnimation = {
            startTime: new Date(),
            durationMs: durationMs,
            startCoords: { x: marker.getLatLng().lng, y: marker.getLatLng().lat },
            endCoords: coords,
            callbackHandle: window.requestAnimationFrame(() => animateMarkerMoveFrame(marker))
        };
    }

    function animateMarkerMoveFrame(marker) {
        var anim = marker.existingAnimation;
        var proportionCompleted = (new Date().valueOf() - anim.startTime.valueOf()) / anim.durationMs;
        var coordsNow = {
            x: anim.startCoords.x + (anim.endCoords.x - anim.startCoords.x) * proportionCompleted,
            y: anim.startCoords.y + (anim.endCoords.y - anim.startCoords.y) * proportionCompleted
        };

        marker.setLatLng([coordsNow.y, coordsNow.x]);

        if (proportionCompleted < 1) {
            marker.existingAnimation.callbackHandle = window.requestAnimationFrame(
                () => animateMarkerMoveFrame(marker));
        }
    }
})();
