CREATE TABLE [dbo].[ReceiverData] (
    [ReceiverID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NOT NULL,
    [Email]      NVARCHAR (MAX) NOT NULL,
    [Phone]      NVARCHAR (15)  NOT NULL,
    CONSTRAINT [PK_ReceiverData] PRIMARY KEY CLUSTERED ([ReceiverID] ASC)
);

