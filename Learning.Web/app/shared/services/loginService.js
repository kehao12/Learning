(function (app) {
    'use strict';
    app.service('loginService', ['$http', '$q', 'authenticationService', 'authData',
        function ($http, $q, authenticationService, authData) {
            var userInfo;
            var deferred;
            var username 
           

            this.login = function (userName, password) {
                deferred = $q.defer();
                var data = "grant_type=password&username=" + userName + "&password=" + password;
                username = userName;
                $http.post('/oauth/token', data, {
                    headers:
                        { 'Content-Type': 'application/x-www-form-urlencoded' }
                }).success(function (response) {
                    userInfo = {
                        accessToken: response.access_token,
                        userName: username
                    };
                    authenticationService.setTokenInfo(userInfo);
                    authData.authenticationData.IsAuthenticated = true;
                    authData.authenticationData.userName = userName;
                    deferred.resolve(null);
                })
                    .error(function (err, status) {
                        authData.authenticationData.IsAuthenticated = false;
                        authData.authenticationData.userName = "";
                        deferred.resolve(err);
                    });
                return deferred.promise;
            }

            this.logOut = function () {
                authenticationService.removeToken();
                authData.authenticationData.IsAuthenticated = false;
                authData.authenticationData.userName = "";
            }
        }]);
})(angular.module('learning.common'));