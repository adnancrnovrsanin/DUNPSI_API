using Domain;

namespace Application.Core
{
    public static class Converters
    {
        public static RequirementApproveStatus ConvertToRequirementApproveStatus(string status)
        {
            return status switch
            {
                "APPROVED" => RequirementApproveStatus.APPROVED,
                "PENDING" => RequirementApproveStatus.PENDING,
                "CHANGES_REQUIRED" => RequirementApproveStatus.CHANGES_REQUIRED,
                _ => RequirementApproveStatus.REJECTED
            };
        }
    }
}