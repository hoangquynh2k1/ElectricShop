/// <reference path="../angular.min.js" />
var myapp = angular.module('SanPhamApp', []);
myapp.controller("HomeController",
    function ($rootScope, $scope, $http) {
        $http.get('/Home/LaySP').then(function (d) {
            $rootScope.lsp = d.data;
        },
            function (error) {
            alert('That bai');
            });
        $scope.sortcolumn = "KhoiLuong";
        $scope.reverse = true;
        $scope.dr = "Ascending";
        $scope.ChonS = function (d) {
            if ($scope.dr == "Ascending") {
                $scope.reverse = false;
                $scope.dr = "Decreasing";
            } else {
                $scope.reverse = true;
                $scope.dr = "Ascending";
            }
        }
        $scope.Chon = function (l) {
            sessionStorage.setItem("MaSP", l);
        }
        var masp = sessionStorage.getItem("MaSP");
        $http({
            method: "get",
            url: "/Home/LaySPCT/",
            params: { ma: masp }
        }).then(function Success(d) {
            $scope.sp = d.data;
        }, function error(e) {
            alert("Lấy sản phẩm lỗi");
        });

    });
var loginapp = angular.module('DangNhapApp', []);
myapp.controller("DangNhapController",
    function ($scope, $http,$rootScope)
    {
        //$rootScope.close = "";
        //$rootScope.khach = null;
        //$rootScope.login = "0";
        //$rootScope.remember = false;
        $rootScope.Logout = function ()
        {
            $http({
                url: '/Home/Logout', method: 'get'
            }).then(function (d)
            {
                $rootScope.log = "Login";
            }, function () { });
        };
        $scope.Login = function (un, pw) {
            $http({
                url: '/Home/Login', method: 'get', params: { us: un, pw: pw }
            }).then(function success(d)
            {
                if (d.data.login == "1")
                {
                    $rootScope.close = "modal";
                    alert("Đăng nhập thành công!");
                }
                else
                {
                    alert("Đăng nhập thất bại");
                }
            })
        }
    }
);



       /*$scope.SelectDongSP = function (l) {
            localStorage.setItem("MaDongSP", l);}
        $http({
            method: "get",
            url: "/Home/LaySPLoai",
            params: { MaDongSP: madong }//localStorage.getItem("MaLoai") }
        }).then(function Success(d) {
            $scope.listSanPham = d.data;
        }, function error(e) {
            alert("Lấy sản phẩm lỗi");
        });*/
/*var homeapp = angular.module("CustommerApp", ['angularUtils.directives.dirPagination']);

homeapp.controller("MenuController",
    function ($scope, $rootScope, $http) {
        $http({
            method: 'get',
            url: '/Home/GetDongSP'
        }).then(function Success(d) {

            $rootScope.listDongSP = d.data;
        },
            function Error() {
                alert("Lấy dòng sản phẩm lỗi");
            });
        $scope.SelectDongSP = function (l) {
            localStorage.setItem("MaDongSP", l);
        }
        var madong = localStorage.getItem("MaDongSP");
        $http({
            method: "get",
            url: "/SanPham/GetSanPhamDong",
            params: { MaDongSP: madong }//localStorage.getItem("MaLoai") }
        }).then(function Success(d) {
            $scope.listSanPham = d.data;
        }, function error(e) {
            alert("Lấy sản phẩm lỗi");
        });
    });
homeapp.controller("SanPhamController", function ($scope, $rootScope, $http) {
    var madong = localStorage.getItem("MaDongSP");
    $http({
        method: "get",
        url: "/SanPham/GetSanPhamDong",
        params: { MaDongSP: madong }//localStorage.getItem("MaLoai") }
    }).then(function Success(d) {
        $scope.listSanPham = d.data;
    }, function error(e) {
        alert("Lấy sản phẩm lỗi");
    });

});*/