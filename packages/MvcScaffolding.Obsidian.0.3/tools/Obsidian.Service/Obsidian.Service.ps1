[T4Scaffolding.Scaffolder(Description = "Generates a service layer")][CmdletBinding()]
param(        
	[parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)][string]$ModelType,   
    [parameter(Mandatory = $false, ValueFromPipelineByPropertyName = $true)][string]$OutputProjectName,
	[string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

$foundModelType = Get-ProjectType $ModelType -Project $Project -BlockUi
if (!$foundModelType) { return }

$serviceName = $ModelType + "Service"

Write-Host "Scaffolding $serviceName..."

$templateName = "Obsidian.ServiceTemplate"
$templateFile = Find-ScaffolderTemplate $templateName -TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -ErrorIfNotFound

if (!$OutputProjectName) {
	$OutputProjectName = $Project
}

$OutputProject = (Get-Project $OutputProjectName)

$defaultNamespace = (Get-Project $OutputProjectName).Properties.Item("DefaultNamespace").Value

if ($templateFile) {
	$outputPath = $serviceName  #Join-Path Controllers $ControllerName
	
	# Prepare all the parameter values to pass to the template, then invoke the template with those values
	$modelTypeNamespace = [T4Scaffolding.Namespaces]::GetNamespace($foundModelType.FullName)
	$relatedEntities = [Array](Get-RelatedEntities $foundModelType.FullName -Project $project)
	$serviceInterfaceName = "I" + $serviceName
	$serviceType = Get-ProjectType $serviceInterfaceName -Project $Project -BlockUi
	$serviceInterfaceNameSpace = [T4Scaffolding.Namespaces]::GetNamespace($serviceType.FullName)
	
	if (!$relatedEntities) { $relatedEntities = @() }
	Add-ProjectItemViaTemplate $outputPath -Template $templateName -Model @{
		ModelType = [MarshalByRefObject]$foundModelType; 
		ModelTypeNamespace = $modelTypeNamespace; 
		ServiceName = $serviceName;
		ServiceInterfaceName = $serviceInterfaceName;
		ServiceTypeNamespace = $defaultNamespace;
		ServiceInterfaceNamespace = $serviceInterfaceNameSpace;
	} -SuccessMessage "Added service {0}" -TemplateFolders $TemplateFolders -Project $OutputProjectName -CodeLanguage $CodeLanguage -Force:$Force


}