﻿//document.addEventListener("DOMContentLoaded", function () { window.addEventListener("pagehide", function (a) { window.name += "\ue000" + window.pageXOffset + "\ue000" + window.pageYOffset }); if (window.name && -1 < window.name.indexOf("\ue000")) { var a = window.name.split("\ue000"); 3 <= a.length && (window.name = a[0], window.scrollTo(parseFloat(a[a.length - 2]), parseFloat(a[a.length - 1]))) } });