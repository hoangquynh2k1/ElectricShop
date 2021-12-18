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
        $rootScope.logstt = "Đăng nhập";
        $rootScope.myLogIn = "myLogIn";
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
        //$rootScope.AddCart = function (s) {
        //    alert(s);
        //    $rootScope.sanpham = s;
        //    $http({
        //        method: 'Post',
        //        datatype: 'Json',
        //        url: 'GioHang/AddCart',
        //        data: JSON.stringify($rootScope.sanpham)
        //    }).then(function (d) {

        //    }, function () { });
        //};
        $rootScope.AddCart = function (s) {
            if ($rootScope.login == "1") {
                $http({
                    method: 'Post',
                    datatype: 'Json',
                    url: 'GioHang/AddCart',
                    params: { Ma: s.MaSP, Ten: s.TenSP, Thong: s.ThongSoKT, MaD: s.MaDong, Kich: s.KichThuoc, Khoi: s.KhoiLuong, Hinh: s.HinhAnh }
                }).then(function (d) {
                    sessionStorage.setItem("giohang", d.data.giohang);
                }, function () { });
            }
            else {
                alert("Mời bạn đăng nhập để tiến hành mua!");
            }
        };
        
    });
var loginapp = angular.module('DangNhapApp', []);
myapp.controller("DangNhapController",
    function ($scope, $http,$rootScope)
    {
        //$rootScope.close = "";
        $rootScope.khach = null;
        $rootScope.login = "0";
        $rootScope.remember = false;
        if ($rootScope.logstt == "Đăng Xuất") {
            Logout();
        }
        $rootScope.Logout = function ()
        {
            $http({
                url: '/Home/Logout', method: 'get'
            }).then(function (d)
            {
                $rootScope.log = "Login";
                $rootScope.myLogIn = "myLogIn";
            }, function () { });
        };
        $scope.Login = function (un, pw) {
            $rootScope.Customer = null;
            $http({
                url: '/Home/Login', method: 'get', params: { us: un, pw: pw }
            }).then(function success(d)
            {
                if (d.data.login == "1")
                {
                    $rootScope.close = "modal";
                    $rootScope.myLogIn = "";
                    $rootScope.logstt = "Đăng Xuất";
                    $rootScope.Customer = d.data.Khach;
                    if ($rootScope.login != "1") {
                        $rootScope.login = "1";
                        $rootScope.close = "modal";
                        alert("Đăng nhập thành công!");
                    }
                }
                else
                {
                    alert("Đăng nhập thất bại");
                }
            })
        }

        $rootScope.DatHang = function () {
            $rootScope.DonHang.Khach = $rootScope.Khach;
            $rootScope.DonHang.TongTien = $rootScope.ThanhTien;
            $rootScope.DonHang.LCtDonHang = $rootScope.dsDonHang;
            $http({
                method: 'Post',
                datatype: 'Json',
                url: 'DatHang/DatHang',
                data: JSON.stringify($rootScope.DonHang)
            }).then(function (d) { }, function () { });
        };

    }
);

// giỏ hàng
myapp.controller("CartController", function ($rootScope, $scope, $http, $window) {
    $rootScope.DangNhap = "#myModal";
    $rootScope.DatHang = "";
    $rootScope.SoLuong = 0;
    $rootScope.KhachHang = null;
    //lấy về các sản phẩm trong giỏ hàng
    $http({
        method: 'get',
        datatype: 'json',
        url: '/GioHang/GetCarts',
    }).then(function success(d) {
        $rootScope.dsDonHang = d.data.dsDonHang;
        $rootScope.SL = d.data.SoLuong;
        $rootScope.TT = d.data.ThanhTien;
        if ($rootScope.dsDonHang.length > 0) {
            $scope.Het = "false";
        }
        else { $scope.Het = "true"; }
        console.log("So Luong:"); console.log($rootScope.SL);
        console.log("Thanh Tien:"); console.log($rootScope.TT);
    }, function error(e) { alert("Gio Hang loi"); });
    //$rootScope.CheckLogin = function () {
    //            if (d.data.login == "") {
    //                $rootScope.DangNhap = "";
    //                $rootScope.KhachHang = d.data.Khach;
    //                console.log(JSON.stringify($rootScope.Khach));
    //                $http.get('/GioHang/GetCarts').then(function (d) {
    //                    $rootScope.dsDonHang = d.data.DSDonHang;
    //                    $rootScope.Quanity = d.data.SoLuong;
    //                    $rootScope.ThanhTien = d.data.ThanhTien;
    //                }, function (e) { });
    //                $window.location.href = '/DatHang/Index';
    //            }
    //            else {
    //                $rootScope.DangNhap = '#myModal';
    //            }
    //        }, function () {
    //            alert("Customer lỗi");
    //};
}, function () { alert("Lỗi"); });

//đặt hàng
//homeapp.controller("DatHangController", function ($rootScope, $scope, $http, $window) {
//    $rootScope.Customer = null;
//    $http.get('/DatHang/GetCustomer').then(function (d) {
//        $rootScope.Customer = d.data.khach;
//    }, function () {
//        alert("Customer Lỗi")
//    })
//    $rootScope.DatHang = function () {
//        $rootScope.DonHang.Khach = $rootScope.Khach;
//        $rootScope.DonHang.TongTien = $rootScope.ThanhTien;
//        $rootScope.DonHang.LCtDonHang = $rootScope.dsDonHang;
//        $http({
//            method: 'Post',
//            datatype: 'Json',
//            url: 'DatHang/DatHang',
//            data: JSON.stringify($rootScope.DonHang)
//        }).then(function (d) { }, function() { });
//    };
//});







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