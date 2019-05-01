var dssv = [
  new student('31161020013','Nguyễn Thị Minh An','16/12/1998','DH42BI002'),
  new student('31161021295','Phan Lương Minh An','10/10/1998','DH42BI001'),
  new student('31161020836','Đỗ Trọng Bình','11/11/1997','DH42BI002'),
  new student('31161024491','Vũ Thị Thanh Châu','09/01/1998','DH42BI002'),
  new student('31161023018','Cao Nguyễn Quỳnh Chi','04/05/1998','DH42BI001'),
  new student('31161021612','Nguyễn Quốc Cường','18/08/1998','DH42BI001'),
  new student('31161020017','Nguyễn Đình Khánh Du','22/08/1998','DH42BI002'),
  new student('31161020474','Phạm Anh Dũng','29/01/1998','DH42BI001'),
  new student('31161023792','Lê Thành Đạt','06/10/1998','DH42BI002'),
  new student('31161020515','Phạm Huỳnh Đức','30/08/1998','DH42BI001'),
  new student('31161024043','Bùi Sĩ Hiệp','07/04/1998','DH42BI001'),
  new student('31161025161','Hà Thanh Hoài','07/06/1998','DH42BI001'),
  new student('31161020990','Trần Khải Hoàn','08/05/1998','DH42BI001'),
  new student('31161026492','Chung Hoàng Khánh','15/03/1998','DH42BI001'),
  new student('31161026676','Nguyễn Ngọc Đăng Khoa','06/06/1998','DH42BI001'),
  new student('31161024815','Nguyễn Thụy Như Khuê','19/09/1998','DH42BI001'),
  new student('31161023705','Nguyễn Thị Hoài Linh','26/01/1998','DH42BI002'),
  new student('31161022233','Phạm Khánh Linh','05/11/1997','DH42BI002'),
  new student('31161024677','Phạm Hạnh Mai','28/03/1998','DH42BI002'),
  new student('31161021131','Nguyễn Hiếu Mỹ','28/03/1998','DH42BI002'),
  new student('31161024227','Nguyễn Hoàng Nam','04/03/1998','DH42BI001'),
  new student('31161025558','Nguyễn Xuân Ngọc','11/10/1998','DH42BI001'),
  new student('31161023543','Nguyễn Hà Thảo Nhi','27/07/1995','DH42BI001'),
  new student('31161021925','Quan Gia Nhi','19/09/1998','DH42BI002'),
  new student('31161021392','Lê Quỳnh Như','20/06/1998','DH42BI002'),
  new student('31161022532','Nguyễn Thanh Phong','26/02/1998','DH42BI001'),
  new student('31161022907','Trương Thu Phương','08/03/1998','DH42BI002'),
  new student('31161020183','Đỗ Minh Quân','17/12/1998','DH42BI001'),
  new student('31161023590','Nguyễn Ngọc Quỳnh','31/03/1998','DH42BI001'),
  new student('31161026660','Huỳnh Thị Lệ Thu','26/12/1998','DH42BI001'),
  new student('31161021419','Nguyễn Nhật Hoài','Thương','08/01/1998','DH42BI001'),
  new student('31161021641','Nguyễn Anh Thy','17/02/1998','DH42BI002'),
  new student('31161020484','Nguyễn Thụy Khánh Trang','16/03/1998','DH42BI002'),
  new student('31161026355','Mai Minh Trị','24/02/1998','DH42BI001'),
  new student('31161020232','Phạm Thị Bích Tuyền','20/03/1998','DH42BI001'),
  new student('31161024766','Võ Thị Hải Yến','05/02/1998','DH42BI002')
];

function parseJson(result){
  var dssv_detect = [];
  for (var i=0;i<result.length;i++)
  {
    for (var j=0;j<dssv.length;j++){
      if (result[i].Id == dssv[j].mssv)
        dssv_detect.push(dssv[j]);   
    }
  }
  return dssv_detect;
}

function CreateTable(dssv_detect){
	var tbody = document.getElementById('tbSinhVien');
  for (var i=0;i<dssv_detect.length;i++){
		//template String
		content +=`
		<tr>
			<td>${i+1}</td>
			<td>${dssv_detect[i].mssv}</td>
			<td>${dssv_detect[i].hoten}</td>
			<td>${dssv_detect[i].lop}</td>
			<td>${new Date()}</td>
			<td>
				<button class="btn btn-success" onclick="Update(${i})">
				Sửa
				</button>
			</td>
		</tr>
		`
  }
  $('#tdSinhVein').html(content);
}

$(document).ready(function(){
  var client = new studentService();
  client.layDanhSachSinhVienDiemDanh();
});