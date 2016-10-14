CREATE TABLE [dbo].[DonationData] (
    [DonationID] INT            IDENTITY (1, 1) NOT NULL,
    [DonorID]    INT            NOT NULL,
    [FoodType]   NVARCHAR (MAX) NOT NULL,
    [Location]   NVARCHAR (MAX) NOT NULL,
    [PickupTime] DATETIME       NOT NULL,
    [Picture]    IMAGE          NULL,
    CONSTRAINT [PK_DonationData] PRIMARY KEY CLUSTERED ([DonationID] ASC),
    CONSTRAINT [FK_DonationData_DonorData] FOREIGN KEY ([DonorID]) REFERENCES [dbo].[DonorData] ([DonorID])
);

