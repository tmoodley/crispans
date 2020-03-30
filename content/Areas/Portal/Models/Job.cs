using HelpingHands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Areas.Portal.Models
{
    public class Job
    {
        public string Id { get; set; }
        public string Tax { get; set; }

        public string TaxPickup { get; set; }

        public string TaxShipping { get; set; } 

        public DateTime DateAvailable { get; set; }

        public DateTime DateAvailableUtc { get; set; }

        public DateTime DateClosing { get; set; }

        public DateTime DateClosingUtc { get; set; }

        public DateTime? DateClosingSecondary { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public string Classification { get; set; }
        public string Type { get; set; }

        public string Status { get; set; }

        public string PickupLocation { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public string OpeningProcess { get; set; }

        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Diameter { get; set; }
        public int MinTolerance { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal PricePickup { get; set; }

        public decimal PriceShipping { get; set; }

        public int Procedure { get; set; }

        public bool ShowUnofficial { get; set; }

        public bool ShowSubmitted { get; set; }

        public bool ShowPlanTakers { get; set; }

        public bool ShowTeamMembers { get; set; }

        public bool ShowTeamMembersContact { get; set; } 

        public bool HasReferenceTable { get; set; }

        public bool HasSubContractorTable { get; set; }

        public bool PreQualSubContractorsOnly { get; set; }

        public int NumReferencesRequired { get; set; }

        public bool HasSummaryTable { get; set; }

        public string SummaryTableName { get; set; }

        public bool IsSubTotalOnSummary { get; set; }

        public string SelectedTablesForSummary { get; set; }

        public string BidFormsHeadingText { get; set; }

        public string TermsAndConditionsHeadingText { get; set; }

        public string ReferenceHeadingText { get; set; }

        public string SubContractorHeadingText { get; set; }

        public string QuestionHeadingText { get; set; }

        public string SummaryTableHeadingText { get; set; }

        public string SummaryTableFooterText { get; set; }

        public DateTime? QuestionDeadline { get; set; }

        public bool IsCloseQuestionsAfterDeadline { get; set; }

        public bool IncludeOtherDocument { get; set; }

        public bool AllowBidDocumentPreview { get; set; }

        public string BondHeadingText { get; set; }
        public string Title { get; set; }

        public string BondTitle { get; set; }

        public string BondTitle2 { get; set; }

        public string TermsAndConditionsChevronLabel { get; set; }

        public string InstructionPageText { get; set; }

        public bool ProvideInstructionsPage { get; set; }

        public string EstimatedValue { get; set; }

        public Decimal? TotalContractAmount { get; set; }

        public bool ShowPurchasingRepsOnPublic { get; set; }

        public bool AllowFullBidDetailsUrl { get; set; }

        public bool AllowMultipleSubmissions { get; set; }

        public bool ShowOnWebsite { get; set; }

        public bool Evaluations { get; set; }

        public bool BidNotApproved { get; set; }

        public DateTime? DateAwarded { get; set; }

        public bool LeadAgency { get; set; }

        public string ParticipatingAgencies { get; set; }

        public int? NumberOfAgencies { get; set; }

        public string EstimatedAnnualValue { get; set; }

        public string ActualContractValue { get; set; }

        public string ActualAnnualValue { get; set; }

        public bool? PostCloseBidException { get; set; }

        public bool? UnsealManually { get; set; }

        public DateTime? PlannedIssueDate { get; set; }

        public bool IsAttendanceTrackingOn { get; set; }

        public bool IsCloseRegistrationAfterMeetingDate { get; set; }

        public bool Deleted { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastUpdated { get; set; }

        public string LastUpdatedBy { get; set; }

        public string CustomerId { get; set; }
        public Customer Customers { get; set; } 
        public bool isNda { get; set; }
        public Guid TermsDocumentId { get; set; }
        public Guid NdaDocumentId { get; set; }
        public Guid ContractDocumentId { get; set; }
        public Guid CadFileDocumentId { get; set; }

        public ICollection<JobCategory> JobCategories { get; set; }
        public ICollection<JobCertification> JobCertifications { get; set; }
        public ICollection<JobCompanyType> JobCompanyTypes { get; set; }
        public ICollection<JobFileType> JobFileTypes { get; set; }
        public ICollection<JobIndustry> JobIndustries { get; set; }
        public ICollection<JobMachine> JobMachines { get; set; }
        public ICollection<JobMaterial> JobMaterials { get; set; }
        public ICollection<JobQuestion> JobQuestions { get; set; }
    }
}
