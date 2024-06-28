using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyMonHocDoAn.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BIENBANCHAMDECUONG",
                columns: table => new
                {
                    IDBienBan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDangKy = table.Column<int>(type: "int", nullable: true),
                    MaHoiDong = table.Column<int>(type: "int", nullable: true),
                    MaGiangVien = table.Column<int>(type: "int", nullable: true),
                    Diem = table.Column<double>(type: "float", nullable: true),
                    DanhGia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinhChung = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BIENBANC__61A114E2EED07913", x => x.IDBienBan);
                });

            migrationBuilder.CreateTable(
                name: "CHITIETDONXINGIAHAN",
                columns: table => new
                {
                    MaCTDXGH = table.Column<int>(type: "int", nullable: false),
                    NgayGiaHan = table.Column<DateOnly>(type: "date", nullable: true),
                    NgayHoanThanh = table.Column<DateOnly>(type: "date", nullable: true),
                    LinkDonXin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAccept = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CHITIETD__79A1495864A38662", x => x.MaCTDXGH);
                });

            migrationBuilder.CreateTable(
                name: "CHITIETHOIDONGDECUONG",
                columns: table => new
                {
                    IDCT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHoiDong = table.Column<int>(type: "int", nullable: false),
                    MaGiangVien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHITIETHOIDONGDECUONG", x => x.IDCT);
                });

            migrationBuilder.CreateTable(
                name: "CHITIETHOIDONGNGHIEMTHU",
                columns: table => new
                {
                    IDCT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHoiDong = table.Column<int>(type: "int", nullable: false),
                    MaGiangVien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHITIETHOIDONGNGHIEMTHU", x => x.IDCT);
                });

            migrationBuilder.CreateTable(
                name: "CHITIETNHOM",
                columns: table => new
                {
                    IdCTNhom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhom = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MaSoSinhVien = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IDDangKy = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHITIETNHOM", x => x.IdCTNhom);
                });

            migrationBuilder.CreateTable(
                name: "CHUONGTRINH",
                columns: table => new
                {
                    MaCT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenCT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHUONGTRINH", x => x.MaCT);
                });

            migrationBuilder.CreateTable(
                name: "DANGKY",
                columns: table => new
                {
                    IDDangKy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDeTai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaNhom = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    MaSoSinhVien = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MaGiangVien = table.Column<int>(type: "int", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaHoiDong = table.Column<int>(type: "int", nullable: true),
                    LinkDeCuong = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    NgayDangKy = table.Column<DateTime>(type: "datetime", nullable: true),
                    KetQua = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DANGKY__735660836B7DE7F7", x => x.IDDangKy);
                });

            migrationBuilder.CreateTable(
                name: "GIANGVIEN",
                columns: table => new
                {
                    MaGiangVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSoGiangVien = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    TenGiangVien = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Nganh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TrinhDo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    MaAccount = table.Column<int>(type: "int", nullable: true),
                    MaKhoa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Gmail = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    MaCT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GIANGVIE__C03BEEBAEF35B90B", x => x.MaGiangVien);
                });

            migrationBuilder.CreateTable(
                name: "HOIDONGDUYETDECUONG",
                columns: table => new
                {
                    MaHoiDong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHoiDong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaKhoa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SoLuongTV = table.Column<bool>(type: "bit", nullable: true),
                    MaCT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HOIDONGD__998808B357E61839", x => x.MaHoiDong);
                });

            migrationBuilder.CreateTable(
                name: "KHOA",
                columns: table => new
                {
                    MaKhoa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenKhoa = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KHOA__653904057D92585F", x => x.MaKhoa);
                });

            migrationBuilder.CreateTable(
                name: "NHOM",
                columns: table => new
                {
                    MaNhom = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TenNhom = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValueSql: "(NULL)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NHOM__234F91CDCE31D14F", x => x.MaNhom);
                });

            migrationBuilder.CreateTable(
                name: "THONGBAO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThongBao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NoiDungTb = table.Column<string>(type: "ntext", nullable: true),
                    NgayGui = table.Column<DateOnly>(type: "date", nullable: true),
                    NguoiNhan = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THONGBAO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThongBaoChamLai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Thongbao = table.Column<string>(type: "ntext", nullable: true),
                    MaHoiDong = table.Column<int>(type: "int", nullable: true),
                    IdDangKy = table.Column<int>(type: "int", nullable: true),
                    IsCheck = table.Column<bool>(type: "bit", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TRANGTHAI",
                columns: table => new
                {
                    MaTrangThai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTrangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TRANGTHA__AADE4138B751F8C7", x => x.MaTrangThai);
                });

            migrationBuilder.CreateTable(
                name: "TYPEACCOUNT",
                columns: table => new
                {
                    MaTypeAccount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTypeAccount = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TYPEACCO__4CA6144FEF9249B0", x => x.MaTypeAccount);
                });

            migrationBuilder.CreateTable(
                name: "HOIDONGNGHIEMTHU",
                columns: table => new
                {
                    MaHoiDong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHoiDong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayNghiemThu = table.Column<DateTime>(type: "datetime", nullable: true),
                    MaKhoa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SoLuongTV = table.Column<bool>(type: "bit", nullable: true),
                    MaCT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HOIDONGN__998808B3C1A427BD", x => x.MaHoiDong);
                    table.ForeignKey(
                        name: "FK__HOIDONGNG__MaKho__5629CD9C",
                        column: x => x.MaKhoa,
                        principalTable: "KHOA",
                        principalColumn: "MaKhoa");
                });

            migrationBuilder.CreateTable(
                name: "NGANH",
                columns: table => new
                {
                    MaNganh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenNganh = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MaKhoa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaCT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NGANH__A2CEF50DA21238F5", x => x.MaNganh);
                    table.ForeignKey(
                        name: "FK__NGANH__MaKhoa__59063A47",
                        column: x => x.MaKhoa,
                        principalTable: "KHOA",
                        principalColumn: "MaKhoa");
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNT",
                columns: table => new
                {
                    MaAccount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Pass = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    HoVaTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaTypeAccount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ACCOUNT__0A2B8E3443ADF5D7", x => x.MaAccount);
                    table.ForeignKey(
                        name: "FK__ACCOUNT__MaTypeA__60A75C0F",
                        column: x => x.MaTypeAccount,
                        principalTable: "TYPEACCOUNT",
                        principalColumn: "MaTypeAccount");
                });

            migrationBuilder.CreateTable(
                name: "DETAI",
                columns: table => new
                {
                    MaDeTai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDeTai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaNganh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    NgayThucHien = table.Column<DateTime>(type: "datetime", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime", nullable: true),
                    KinhPhiDuKien = table.Column<decimal>(type: "money", nullable: true),
                    KetQua = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LinkDeTai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaTrangThai = table.Column<int>(type: "int", nullable: true),
                    MaGiangVien = table.Column<int>(type: "int", nullable: true),
                    MaHoiDong = table.Column<int>(type: "int", nullable: true),
                    MaNhom = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    MaSoSinhVien = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DETAI__9F967D5BB67B2C6A", x => x.MaDeTai);
                    table.ForeignKey(
                        name: "FK__DETAI__MaGiangVi__5EBF139D",
                        column: x => x.MaGiangVien,
                        principalTable: "GIANGVIEN",
                        principalColumn: "MaGiangVien");
                    table.ForeignKey(
                        name: "FK__DETAI__MaHoiDong__4E88ABD4",
                        column: x => x.MaHoiDong,
                        principalTable: "HOIDONGNGHIEMTHU",
                        principalColumn: "MaHoiDong");
                    table.ForeignKey(
                        name: "FK__DETAI__MaNganh__4F7CD00D",
                        column: x => x.MaNganh,
                        principalTable: "NGANH",
                        principalColumn: "MaNganh");
                    table.ForeignKey(
                        name: "FK__DETAI__MaTrangTh__5070F446",
                        column: x => x.MaTrangThai,
                        principalTable: "TRANGTHAI",
                        principalColumn: "MaTrangThai");
                });

            migrationBuilder.CreateTable(
                name: "SINHVIEN",
                columns: table => new
                {
                    MaSinhVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSoSinhVien = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaNganh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    CCCD = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    TKNganHang = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    SDT = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Lop = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NienKhoa = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ChiNhanhNganHang = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    MaAccount = table.Column<int>(type: "int", nullable: true),
                    MaNhom = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SINHVIEN", x => x.MaSinhVien);
                    table.ForeignKey(
                        name: "FK__SINHVIEN__MaAcco__571DF1D5",
                        column: x => x.MaAccount,
                        principalTable: "ACCOUNT",
                        principalColumn: "MaAccount");
                });

            migrationBuilder.CreateTable(
                name: "BIENBANNGHIEMTHU",
                columns: table => new
                {
                    IDBienBan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHoiDong = table.Column<int>(type: "int", nullable: true),
                    MaDeTai = table.Column<int>(type: "int", nullable: true),
                    Diem = table.Column<double>(type: "float", nullable: true),
                    NhanXet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkBienBan = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MaGiangVien = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BIENBANN__D0123202EAFC80F7", x => x.IDBienBan);
                    table.ForeignKey(
                        name: "FK__BIENBANNG__MaDeT__4BAC3F29",
                        column: x => x.MaDeTai,
                        principalTable: "DETAI",
                        principalColumn: "MaDeTai");
                    table.ForeignKey(
                        name: "FK__BIENBANNG__MaHoi__4CA06362",
                        column: x => x.MaHoiDong,
                        principalTable: "HOIDONGNGHIEMTHU",
                        principalColumn: "MaHoiDong");
                });

            migrationBuilder.CreateTable(
                name: "DONXINGIAHAN",
                columns: table => new
                {
                    MaDonXinGiaHan = table.Column<int>(type: "int", nullable: false),
                    MaGiangVien = table.Column<int>(type: "int", nullable: true),
                    MaCTDXGH = table.Column<int>(type: "int", nullable: true),
                    MaDeTai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DONXINGI__CD4EFD9BDCF17B9F", x => x.MaDonXinGiaHan);
                    table.ForeignKey(
                        name: "FK__DONXINGIA__MaCTD__6754599E",
                        column: x => x.MaCTDXGH,
                        principalTable: "CHITIETDONXINGIAHAN",
                        principalColumn: "MaCTDXGH");
                    table.ForeignKey(
                        name: "FK__DONXINGIA__MaDeT__52593CB8",
                        column: x => x.MaDeTai,
                        principalTable: "DETAI",
                        principalColumn: "MaDeTai");
                    table.ForeignKey(
                        name: "FK__DONXINGIA__MaGia__6477ECF3",
                        column: x => x.MaGiangVien,
                        principalTable: "GIANGVIEN",
                        principalColumn: "MaGiangVien");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_MaTypeAccount",
                table: "ACCOUNT",
                column: "MaTypeAccount");

            migrationBuilder.CreateIndex(
                name: "IX_BIENBANNGHIEMTHU_MaDeTai",
                table: "BIENBANNGHIEMTHU",
                column: "MaDeTai");

            migrationBuilder.CreateIndex(
                name: "IX_BIENBANNGHIEMTHU_MaHoiDong",
                table: "BIENBANNGHIEMTHU",
                column: "MaHoiDong");

            migrationBuilder.CreateIndex(
                name: "IX_DETAI_MaGiangVien",
                table: "DETAI",
                column: "MaGiangVien");

            migrationBuilder.CreateIndex(
                name: "IX_DETAI_MaHoiDong",
                table: "DETAI",
                column: "MaHoiDong");

            migrationBuilder.CreateIndex(
                name: "IX_DETAI_MaNganh",
                table: "DETAI",
                column: "MaNganh");

            migrationBuilder.CreateIndex(
                name: "IX_DETAI_MaTrangThai",
                table: "DETAI",
                column: "MaTrangThai");

            migrationBuilder.CreateIndex(
                name: "IX_DONXINGIAHAN_MaCTDXGH",
                table: "DONXINGIAHAN",
                column: "MaCTDXGH");

            migrationBuilder.CreateIndex(
                name: "IX_DONXINGIAHAN_MaDeTai",
                table: "DONXINGIAHAN",
                column: "MaDeTai");

            migrationBuilder.CreateIndex(
                name: "IX_DONXINGIAHAN_MaGiangVien",
                table: "DONXINGIAHAN",
                column: "MaGiangVien");

            migrationBuilder.CreateIndex(
                name: "IX_HOIDONGNGHIEMTHU_MaKhoa",
                table: "HOIDONGNGHIEMTHU",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_NGANH_MaKhoa",
                table: "NGANH",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_SINHVIEN_MaAccount",
                table: "SINHVIEN",
                column: "MaAccount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BIENBANCHAMDECUONG");

            migrationBuilder.DropTable(
                name: "BIENBANNGHIEMTHU");

            migrationBuilder.DropTable(
                name: "CHITIETHOIDONGDECUONG");

            migrationBuilder.DropTable(
                name: "CHITIETHOIDONGNGHIEMTHU");

            migrationBuilder.DropTable(
                name: "CHITIETNHOM");

            migrationBuilder.DropTable(
                name: "CHUONGTRINH");

            migrationBuilder.DropTable(
                name: "DANGKY");

            migrationBuilder.DropTable(
                name: "DONXINGIAHAN");

            migrationBuilder.DropTable(
                name: "HOIDONGDUYETDECUONG");

            migrationBuilder.DropTable(
                name: "NHOM");

            migrationBuilder.DropTable(
                name: "SINHVIEN");

            migrationBuilder.DropTable(
                name: "THONGBAO");

            migrationBuilder.DropTable(
                name: "ThongBaoChamLai");

            migrationBuilder.DropTable(
                name: "CHITIETDONXINGIAHAN");

            migrationBuilder.DropTable(
                name: "DETAI");

            migrationBuilder.DropTable(
                name: "ACCOUNT");

            migrationBuilder.DropTable(
                name: "GIANGVIEN");

            migrationBuilder.DropTable(
                name: "HOIDONGNGHIEMTHU");

            migrationBuilder.DropTable(
                name: "NGANH");

            migrationBuilder.DropTable(
                name: "TRANGTHAI");

            migrationBuilder.DropTable(
                name: "TYPEACCOUNT");

            migrationBuilder.DropTable(
                name: "KHOA");
        }
    }
}
