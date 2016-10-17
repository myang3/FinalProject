CREATE TABLE [dbo].[DonationData] (
    [DonationID]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (MAX) NOT NULL,
    [Email]            NVARCHAR (MAX) NOT NULL,
    [Phone]            NVARCHAR (15)  NOT NULL,
    [FoodType]         NVARCHAR (MAX) NOT NULL,
    [Location]         NVARCHAR (MAX) NOT NULL,
    [PickupDate]       NVARCHAR (MAX)  NOT NULL,
    [PickupTime]       NVARCHAR(MAX)       NOT NULL,
    [shortDescription] TEXT           NULL,
    CONSTRAINT [PK_Donation] PRIMARY KEY CLUSTERED ([DonationID] ASC)
);





