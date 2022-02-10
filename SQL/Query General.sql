--Consulta validación user
select
Id_User,
Id_Rol
from
Users
where
User_Name = @User_Name and
Password = @Password

--Insertar nuevos productos
insert into
Products
(
	Cod_Product,
    Name_Product,
    Desc_Product,
    Price_Product,
    Img_Product
)
values
(
	@Cod_Product,
    @Name_Product,
    @Desc_Product,
    @Price_Product,
    @Img_Product
)

--Consulta traer productos
select
Id_Product,
Cod_Product,
Name_Product,
Desc_Product,
Price_Product,
Img_Product
from
Products

--Consulta traer productos por id
select
Id_Product,
Cod_Product,
Name_Product,
Desc_Product,
Price_Product,
Img_Product
from
Products
where
Id_Product = @Id_Product

--Consulta top max vendidos
select top 3
p.Name_Product,
p.Img_Product,
sum(b.Quantity) as 'Quantity'
from
Buys b
inner join Products p on b.Id_Product = p.Id_Product
group by p.Name_Product, p.Img_Product
order by sum(b.Quantity) desc

--Insertar nuevo usuario
insert into
Users
(
User_Name,
Password,
Id_Rol
)
values
(
@User_Name,
@Password,
@Id_Rol
)

--Consulta roles
select
Id_Rol,
Rol_Name
from
Roles






--Consultas de permisos por user
select
u.User_Name,
r.Rol_Name,
m.Module_Name
from
Users u
inner join Roles r on u.Id_Rol = r.Id_Rol
inner join dbo.Permissions p on r.Id_Rol = p.Id_Rol
inner join Modules m on p.Id_Module = m.Id_Module
where
Id_User = @Id_User



