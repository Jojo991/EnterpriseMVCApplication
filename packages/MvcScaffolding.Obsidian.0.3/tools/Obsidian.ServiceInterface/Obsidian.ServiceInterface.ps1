[T4Scaffolding.Scaffolder(Description = "Generates a service layer interface")][CmdletBinding()]
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

$ServiceInterfaceName = "I" + $ModelType + "Service"

Write-Host "Scaffolding $ServiceInterfaceName..."

$templateName = "Obsidian.ServiceInterfaceTemplate"
$templateFile = Find-ScaffolderTemplate $templateName -TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -ErrorIfNotFound

if (!$OutputProjectName) {
	$OutputProjectName = $Project
}

$OutputProject = (Get-Project $OutputProjectName)

$defaultNamespace = (Get-Project $OutputProjectName).Properties.Item("DefaultNamespace").Value

if ($templateFile) {
	$outputPath = $ServiceInterfaceName  #Join-Path Controllers $ControllerName
	
	# Prepare all the parameter values to pass to the template, then invoke the template with those values
	$serviceInterfaceNameSpace = [T4Scaffolding.Namespaces]::GetNamespace($serviceInterfaceType.FullName)
	$modelTypeNamespace = [T4Scaffolding.Namespaces]::GetNamespace($foundModelType.FullName)
	$relatedEntities = [Array](Get-RelatedEntities $foundModelType.FullName -Project $project)
	if (!$relatedEntities) { $relatedEntities = @() }

	Add-ProjectItemViaTemplate $outputPath -Template $templateName -Model @{
		ModelType = [MarshalByRefObject]$foundModelType; 
		ModelTypeNamespace = $modelTypeNamespace; 
		ServiceInterfaceName = $ServiceInterfaceName;
		ServiceInterfaceTypeNamespace = $defaultNamespace; 
	} -SuccessMessage "Added service interface {0}" -TemplateFolders $TemplateFolders -Project $OutputProjectName -CodeLanguage $CodeLanguage -Force:$Force
}