/// <reference path="../angular.min.js" />
var adminapp = angular.module('AdminApp', []);
adminapp.controller("AdminController",
    function ($rootScope, $scope, $http) {
        $http.get('/Admin/LaySP1').then(function (d) {
            $rootScope.lspa = d.data;
        },
            function (error) {
                alert('That bai');
            });
        $scope.Xoa = function Xoa(A) {
            $http({
                method: "get",
                url: "/Admin/Xoa/",
                params: { ma: A }
            }).then(function Success(d) {
                if (d == "")
                    alert("Xoa Thanh cong")
            }, function error(e) {
                alert("Lấy sản phẩm lỗi");
            });
        }
        $scope.Sua = function Abc(A) {
            $scope.acb = A;
        }
        $scope.LuuSua = function Sua(acb) {
            var pr = angular.copy(acb);
            $http({
                method: "get",
                url: "/Admin/Sua/",
                params: { ma: pr }
            }).then(function Success(d) {
                if (d == "")
                    alert("Sua Thanh cong")
                else alert(d)
            }, function error(e) {
                alert("Lấy sản phẩm lỗi");
            });
        }
    }
);


