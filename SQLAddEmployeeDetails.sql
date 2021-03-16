create PROCEDURE [dbo].[SpAddEmployeeDetails]
(
@id varchar(255),
@name varchar (255),
@basicpay float,
@start date,
@gender varchar(225),
@phone float,
@address varchar(225),
@department varchar(225),
@deduction float,
@taxable_pay float,
@income_tax float,
@net_pay float 
)
as begin
insert into employee_payroll values (@id,@name,@basic_pay,@start,@gender,@phone,@address,@department,@deduction,@taxable_pay,@income_tax,@net_pay)
end