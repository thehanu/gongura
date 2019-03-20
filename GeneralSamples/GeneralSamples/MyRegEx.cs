using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeneralSamples
{
    class MyRegEx
    {
        public static void MatchRegex()
        {
            string title = "MissingServicePrimaryHB: Region - USGovEast - fabric:/rnm/macmanager/02";
            Regex regex = new Regex(@"^MissingServicePrimaryHB: Region - \w+ - fabric:/rnm.+", RegexOptions.IgnoreCase);
            Match match = regex.Match(title);

            title = "RNM MacManager Low On Mac ERROR Event@ Region: USCentraleuap - PercentageFree: 19.073486328125";
            regex = new Regex(@"^RNM MacManager Low On Mac ERROR Event@ Region: .+ -PercentageFree: .+", RegexOptions.IgnoreCase);
            match = regex.Match(title);

            title = "[WABO] [Prod] [CBY07PrdApp01] WorkItem [OD_1123516]_Generate_Cluster_Model_Files failed with error: Failed to run DCMT operation in source depot mode: code review failed after 21 attempts at Activity \"[OD:1123516] Generate Cluster Model Files\"";
            regex = new Regex(@"^\[WABO\] \[Prod\] \[.+\] WorkItem \[.+\]_Generate_Cluster_Model_Files failed with error: .+", RegexOptions.IgnoreCase);
            match = regex.Match(title);

            title = "[WABO] [Prod] [CBY07PrdApp01] Ownership enforcer is getting rejected as RNM-DCMT validations is failing during Buddy build";
            regex = new Regex(@"^\[WABO\] \[Prod\] \[.+\] Ownership enforcer is getting rejected .+", RegexOptions.IgnoreCase);
            match = regex.Match(title);

            title = "RNM Service Execution Failure@ Region: RNMServiceExecutionEventUSEastVer3v0, ApiName: SetAccessRule, Subscription: , RnmPartitionId: RNM_BL4PrdPFCC01_03";
            regex = new Regex(@"^RNM Service Execution Failure@ Region: .+, ApiName: SetAccessRule, Subscription:.*, RnmPartitionId:.+", RegexOptions.IgnoreCase);
            match = regex.Match(title);

            title = "[TooManyNodesAreUnhealthy] RNMAlerts [Prod_USCentral_RnmMonitorTooManyUnHealthyNodes] is unhealthy.";
            regex = new Regex(@"^\[TooManyNodesAreUnhealthy\] RNMAlerts \[.+\] is unhealthy.", RegexOptions.IgnoreCase);
            match = regex.Match(title);

            title = "201801110000: Missing usage data for resources under SoldService: Virtual Network has exceeded threshold";
            regex = new Regex(@"^\d+: Missing usage data for resources under SoldService: .+", RegexOptions.IgnoreCase);
            match = regex.Match(title);

            title = "RNM Vip Mobility ERROR Event@ Region: RNMAlertsEventUSEast2euapVer3v0";
            regex = new Regex(@"^RNM Vip Mobility ERROR Event@ Region: .+", RegexOptions.IgnoreCase);
            match = regex.Match(title);

            title = "[[RNM] Critical Event Frontend Operation] RegionAndEventCodeRnm [RnmServiceInstanceCleanupTimeout_useast2] is unhealthy.";
            regex = new Regex(@"\[\[RNM\] Critical Event Frontend Operation\] RegionAndEventCodeRnm \[.+] is unhealthy.", RegexOptions.IgnoreCase);
            match = regex.Match(title);

            title = "RDFE Mac Preservation Qos ERROR @ Region: europenorth - Sub: 6e59fa43-32aa-45db-9eb6-aedf34e5673b - Deployment: 4ba38b8c73cd4cacaf7c863c517e9bbf - Operation: PrepareMacReservationRequests. Execute TSG 6183903";
            regex = new Regex(@"^RDFE Mac Preservation Qos ERROR @ Region: .+ - Sub: .+ - Deployment: .+ - Operation: .+", RegexOptions.IgnoreCase);
            match = regex.Match(title);

            title = "RNM Service migration Failure ERROR Event@ Region: RNMAlertsEventEuropeNorthVer3v0. Execute TSG: 5578319";
            regex = new Regex(@"^RNM Service migration Failure ERROR Event@ Region: .+ Execute TSG: \d+", RegexOptions.IgnoreCase);
            match = regex.Match(title);

            title = "[[RNM] NRP-RNM Reconciliation Critical Event Alert] RegionAndEventCodeRnm [InvalidRnmAllocatedCAs_useast2] is unhealthy.";
            regex = new Regex(@"^\[\[RNM\] NRP-RNM Reconciliation Critical Event Alert\] RegionAndEventCodeRnm \[.+\] is unhealthy.", RegexOptions.IgnoreCase);
            match = regex.Match(title);

            title = "ApiUnexpectedFailures exceeded thresholds for  ApiName: virtualmachines.resourceoperation.delete. Location: eastus2. ResultCode: networkinginternaloperationerror. ApiUnexpectedFailuresCount = 50 over last 30 minutes ApiUnexpectedFailuresRatio = 0.06353240152477764 over last 30 minutes ApiUnexpectedFailuresFailedSubIdCount = 4 over last 30 minutes";
            regex = new Regex(@"^ApiUnexpectedFailures exceeded thresholds for  ApiName: virtualmachines.resourceoperation.delete. Location: .+. ResultCode: .+", RegexOptions.IgnoreCase);
            match = regex.Match(title);

            title = "RNM Service Execution Failure@ Region: RNMServiceExecutionEventEuropeWestVer3v0, ApiName: ReserveVip, Subscription: 420628ed-f183-4860-b8c5-4e00d22ec4e7, RnmPartitionId: RNM_AM4PrdPFCC01_01";
            regex = new Regex(@"^RNM Service Execution Failure@ Region: .+, ApiName: ReserveVip, Subscription: .+, RnmPartitionId: .+", RegexOptions.IgnoreCase);
            match = regex.Match(title);

            title = "NRP incorrectly returns NetworkInterfaceCountExceeded attempting to add 2nd NIC to Standard_E32-8s_v3 size VM | 118011117451718";
            regex = new Regex(@"^NRP incorrectly returns NetworkInterfaceCountExceeded attempting to add .+", RegexOptions.IgnoreCase);
            match = regex.Match(title);

            title = "RNM Service Execution Failure@ Region: RNMServiceExecutionEventUSEastVer3v0, ApiName: GetEffectiveRouteGroups, Subscription: fb7f642a-16cf-48a7-8161-58002441290d, RnmPartitionId: RNM_BL4PrdPFCC01_05";
            regex = new Regex(@"^RNM Service Execution Failure@ Region: .+, ApiName: GetEffectiveRouteGroups, Subscription: .+", RegexOptions.IgnoreCase);
            match = regex.Match(title);

            title = "RNM Service Execution Failure@ Region: RNMServiceExecutionEventUSGovEastVer3v0, ApiName: GetEffectiveAclGroups, Subscription: 8b4c587d-79af-4b55-bc2b-709690a25e0a, RnmPartitionId: RNM_BN1UFCAzF_01";
            regex = new Regex(@"^RNM Service Execution Failure@ Region: .+, ApiName: GetEffectiveAclGroups, Subscription: .+, RnmPartitionId: .+", RegexOptions.IgnoreCase);
            match = regex.Match(title);   
        }
    }
}
