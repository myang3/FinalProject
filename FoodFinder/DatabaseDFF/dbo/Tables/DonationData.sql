CREATE TABLE [dbo].[DonationData] (
    [DonationID]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (MAX) NOT NULL,
    [Email]            NVARCHAR (MAX) NOT NULL,
    [Phone]            NVARCHAR (15)  NOT NULL,
    [FoodType]         NVARCHAR (MAX) NULL,
    [Location]         NVARCHAR (MAX) NOT NULL,
    [PickupDate]       NVARCHAR (50)  NOT NULL,
    [PickupTime]       NVARCHAR (50)  NOT NULL,
    [shortDescription] TEXT           NULL,
    [ExpireTime]       NVARCHAR (50)  NULL,
    CONSTRAINT [PK_Donation] PRIMARY KEY CLUSTERED ([DonationID] ASC)
);







