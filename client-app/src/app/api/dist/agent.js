"use strict";
exports.__esModule = true;
var axios_1 = require("axios");
axios_1["default"].defaults.baseURL = 'http://localhost:5000/api';
var responseBody = function (response) { return response.data; };
var request = {
    get: function (url) { return axios_1["default"].get(url).then(responseBody); },
    post: function (url, body) { return axios_1["default"].post(url, body).then(responseBody); },
    put: function (url, body) {
        return ;
    }
};
