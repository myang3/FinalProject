CREATE TABLE [dbo].[DonorData] (
    [DonorID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (MAX) NOT NULL,
    [Email]   NVARCHAR (MAX) NOT NULL,
    [Phone]   NVARCHAR (15)  NOT NULL,
    CONSTRAINT [PK_UserData_1] PRIMARY KEY CLUSTERED ([DonorID] ASC)
);

