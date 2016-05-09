select * from [dbo].[usuario]


update usuario
 set Foto=(SELECT BulkColumn FROM OPENROWSET(Bulk 'D:\Test\TestToken\Fotos\Familia.jpg', SINGLE_BLOB) AS BLOB)
 where IdUsuario=1

 update usuario
 set Foto=(SELECT BulkColumn FROM OPENROWSET(Bulk 'D:\Test\TestToken\Fotos\Mamatol.jpg', SINGLE_BLOB) AS BLOB)
 where IdUsuario=2