function studentService(){
  
  this.layDanhSachSinhVienDiemDanh = function(){
    $.ajax({
      url: "localhost:50745/api/faces",
      type: "get",
    })
    .done(function(result){
      console.log(result);
      var dssv_detect = parseJson(result);
      CreateTable(dssv_detect);
    })
    .fail(function(error){
      console.log(error);
    })
  }
}