<!-- default file list -->
*Files to look at*:

* [ValidateDetailViewController.cs](./CS/WinSolution.Module.Win/ValidateDetailViewController.cs) (VB: [ValidateDetailViewController.vb](./VB/WinSolution.Module.Win/ValidateDetailViewController.vb))
* [DomainObject1.cs](./CS/WinSolution.Module/DomainObject1.cs) (VB: [DomainObject1.vb](./VB/WinSolution.Module/DomainObject1.vb))
<!-- default file list end -->
# OBSOLETE - How to validate objects when navigating between records and the list view is in the ListViewAndDetailView mode


<p><strong>=================================</strong><br /><strong>This example is now obsolete. Instead, set the <a href="https://documentation.devexpress.com/Xaf/DevExpressExpressAppSystemModuleModificationsController_ModificationsHandlingModetopic.aspx">ModificationsController.ModificationsHandlingMode</a> property to AutoCommit.</strong><br /><strong>=================================</strong><br /><br />By default, XAF objects are not immediately validated when moving between records in the list or detail view and when using the navigation buttons or selecting records in the grid. This example demonstrates how to work around this design and prompt a user once he is about to leave the edit mode and go to another record.</p>

<br/>


