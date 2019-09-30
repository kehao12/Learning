/// <reference path="../../../node_modules/angular/angular.js" />
(function (app) {
    app.factory('apiService', apiService);

    apiService.$inject = ['$http', 'notificationService', 'authenticationService', '$injector'];

    function apiService($http, notificationService, authenticationService, $injector) {
        return {
            get: get,
            post: post,
            put: put,
            del: del
        }
        function del(url, data, success, failure) {
            authenticationService.setHeader();
            $http.delete(url, data).then(function (result) {
                success(result);
            }, function (error) {
               // console.log(error.status)
                if (error.status === 401) {
                    notificationService.displayError('Bạn không đủ quyền truy cập.');
                    var stateService = $injector.get('$state');
                    stateService.go('login');
                }
                else if (failure != null) {
                    failure(error);
                }

            });
        }
        function post(url, data, success, failure) {
            authenticationService.setHeader();
            $http.post(url, data).then(function (result) {
                success(result);
            }, function (error) {
                //console.log(error.status)
                if (error.status === 401) {
                    notificationService.displayError('Bạn không đủ quyền truy cập.');
                    var stateService = $injector.get('$state');
                    stateService.go('login');
                }
                else if (failure != null) {
                    failure(error);
                }

            });
        }
        function put(url, data, success, failure) {
            authenticationService.setHeader();
            $http.put(url, data).then(function (result) {
                success(result);
            }, function (error) {
               // console.log(error.status)
                if (error.status === 401) {
                    notificationService.displayError('Bạn không đủ quyền truy cập.');
                    var stateService = $injector.get('$state');
                    stateService.go('login');
                }
                else if (failure != null) {
                    failure(error);
                }

            });
        }
        function get(url, params, success, failure) {
            authenticationService.setHeader();
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                    //console.log(error.status)
                    if (error.status === 401) {
                        notificationService.displayError('Bạn không đủ quyền truy cập.');
                        var stateService = $injector.get('$state');
                        stateService.go('login');
                    }
                    else if (failure != null) {
                        failure(error);
                    }

                });
        }
    }
})(angular.module('learning.common'));