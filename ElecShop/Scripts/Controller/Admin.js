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
                params: { ma: A.MaSP }
            }).then(function Success(d) {
                $http.get('/Admin/LaySP1').then(function (d) {
                    $rootScope.lspa = d.data;
                },
                    function (error) {
                        alert('That bai');
                    });
            }, function error(e) {
                alert("Xoa Loi");
            });
        }
        $scope.Sua = function Abc(A) {
            $scope.acb = A;
        }
        $scope.LuuSua = function Sua(acb) {
            var MaSP, TenSP, ThongSoKT, MaDong, KichThuoc, KhoiLuong, HinhAnh;
            MaSP = acb.MaSP;
            TenSP = acb.TenSP;
            ThongSoKT = acb.ThongSoKT;
            MaDong = acb.MaDong;
            KichThuoc = acb.KichThuoc;
            KhoiLuong = acb.KhoiLuong;
            HinhAnh = acb.HinhAnh;
            $http({
                method: "get",
                url: "/Admin/Sua/",
                params: { Ma: MaSP, Ten: TenSP, Thong: ThongSoKT, MaD: MaDong, Kich: KichThuoc, Khoi: KhoiLuong, Hinh: HinhAnh }
            }).then(function Success(d) {
                if (d == "")
                    alert("Sua Thanh cong")
            }, function error(e) {
                alert("Lấy sản phẩm lỗi");
            });
        }
        $scope.LuuSua = function Sua(acb) {
            var MaSP, TenSP, ThongSoKT, MaDong, KichThuoc, KhoiLuong, HinhAnh;
            MaSP = acb.MaSP;
            TenSP = acb.TenSP;
            ThongSoKT = acb.ThongSoKT;
            MaDong = acb.MaDong;
            KichThuoc = acb.KichThuoc;
            KhoiLuong = acb.KhoiLuong;
            HinhAnh = acb.HinhAnh;
            $http({
                method: "get",
                url: "/Admin/Sua/",
                params: { Ma: MaSP, Ten: TenSP, Thong: ThongSoKT, MaD: MaDong, Kich: KichThuoc, Khoi: KhoiLuong, Hinh: HinhAnh }
            }).then(function Success(d) {
                if (d == "")
                    alert("Sua Thanh cong")
            }, function error(e) {
                alert("Sửa sản phẩm lỗi");
            });
        };
        $scope.Them = function Them(a0, a1, a2, a3, a4, a5, a6) {
            $http({
                method: "get",
                url: "/Admin/Them/",
                params: { Ma: a0, Ten: a1, Thong: a2, MaD: a4, Kich: a3, Khoi: a5, Hinh: a6 }
            }).then(function Success(d) {
                if (d == "")
                    alert("Sua Thanh cong")
            }, function error(e) {
                alert("Thêm sản phẩm lỗi");
            });

        };
    }
);