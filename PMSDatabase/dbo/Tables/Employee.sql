CREATE TABLE [dbo].[Employee] (
    [EmployeeOID] INT           IDENTITY (1, 1) NOT NULL,
    [EmployeeID]  VARCHAR (10)  NOT NULL,
    [Name]        NVARCHAR (30) NOT NULL,
    [Email]       VARCHAR (64)  NOT NULL,
    [Mobile]      VARCHAR (30)  NULL,
    [Tel]         VARCHAR (30)  NULL,
    [CompanyCode] NVARCHAR (6)  NOT NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([EmployeeID] ASC),
    CONSTRAINT [FK_Employee_CompanyInfo] FOREIGN KEY ([CompanyCode]) REFERENCES [dbo].[CompanyInfo] ([CompanyCode])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'公司員工資料
PK
DF:''P''
SP UPDATE:P+9碼識別碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employee';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'公司員工資料識別碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employee', @level2type = N'COLUMN', @level2name = N'EmployeeOID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'員工編號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employee', @level2type = N'COLUMN', @level2name = N'EmployeeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'姓名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employee', @level2type = N'COLUMN', @level2name = N'Name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'電子信箱', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employee', @level2type = N'COLUMN', @level2name = N'Email';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'手機', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employee', @level2type = N'COLUMN', @level2name = N'Mobile';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'市話', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employee', @level2type = N'COLUMN', @level2name = N'Tel';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'公司代碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Employee', @level2type = N'COLUMN', @level2name = N'CompanyCode';

