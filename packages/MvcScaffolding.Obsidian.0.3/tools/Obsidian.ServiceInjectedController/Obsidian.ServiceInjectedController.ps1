[T4Scaffolding.ControllerScaffolder("(Obsidian) Controller with a service layer to implement business logic.", Description = "Generate a controller which use a service layer to implement business logic.", SupportsModelType = $true, SupportsDataContextType = $false, SupportsViewScaffolder = $true)][CmdletBinding()]
param(        
	[parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)][string]$ModelType,   
    [string]$Project,
	[string]$CodeLanguage,
	[string]$Area,
	[alias("MasterPage")][string]$Layout,
 	[alias("ContentPlaceholderIDs")][string[]]$SectionNames,
	[alias("PrimaryContentPlaceholderID")][string]$PrimarySectionName,
	[switch]$ReferenceScriptLibraries = $false,
	[switch]$NoChildItems = $false,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

if (!((Get-ProjectAspNetMvcVersion -Project $Project) -ge 3)) {
	Write-Error ("Project '$((Get-Project $Project).Name)' is not an ASP.NET MVC 3 project.")
	return
}

$foundModelType = Get-ProjectType $ModelType -Project $Project -BlockUi
if (!$foundModelType) { return }

$ControllerName = $ModelType + "Controller"

Write-Host "Scaffolding $ControllerName..."

$primaryKey = Get-PrimaryKey $foundModelType.FullName -Project $Project -ErrorIfNotFound
if (!$primaryKey) { return }

$templateName = "Obsidian.ServiceInjectedControllerTemplate"

$serviceInterfaceTypeName = "I" + $ModelType + "Service" 
$serviceInterfaceType = Get-ProjectType $serviceInterfaceTypeName -Project $Project -BlockUi

$outputPath = Join-Path Controllers $ControllerName
	
# We don't create areas here, so just ensure that if you specify one, it already exists
if ($Area) {
	$areaPath = Join-Path Areas $Area
	if (-not (Get-ProjectItem $areaPath -Project $Project)) {
		Write-Error "Cannot find area '$Area'. Make sure it exists already."
		return
	}
	$outputPath = Join-Path $areaPath $outputPath
}

# Prepare all the parameter values to pass to the template, then invoke the template with those values
$serviceInterfaceNameSpace = [T4Scaffolding.Namespaces]::GetNamespace($serviceInterfaceType.FullName)
$defaultNamespace = (Get-Project $Project).Properties.Item("DefaultNamespace").Value
$modelTypeNamespace = [T4Scaffolding.Namespaces]::GetNamespace($foundModelType.FullName)
$controllerNamespace = [T4Scaffolding.Namespaces]::Normalize($defaultNamespace + "." + [System.IO.Path]::GetDirectoryName($outputPath).Replace([System.IO.Path]::DirectorySeparatorChar, "."))
$areaNamespace = if ($Area) { [T4Scaffolding.Namespaces]::Normalize($defaultNamespace + ".Areas.$Area") } else { $defaultNamespace }
$modelTypePluralized = Get-PluralizedWord $foundModelType.Name
$relatedEntities = [Array](Get-RelatedEntities $foundModelType.FullName -Project $project)
if (!$relatedEntities) { $relatedEntities = @() }

Add-ProjectItemViaTemplate $outputPath -Template $templateName -Model @{
	ControllerName = $ControllerName;
	ModelType = [MarshalByRefObject]$foundModelType; 
	PrimaryKey = [string]$primaryKey; 
	ModelTypeNamespace = $modelTypeNamespace; 
	ControllerNamespace = $controllerNamespace; 
	ServiceInterfaceTypeNamespace = $serviceInterfaceNameSpace; 
	RelatedEntities = $relatedEntities;
} -SuccessMessage "Added controller {0}" -TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -Force:$Force

if (!$NoChildItems) {

	$controllerNameWithoutSuffix = [System.Text.RegularExpressions.Regex]::Replace($ControllerName, "Controller$", "", [System.Text.RegularExpressions.RegexOptions]::IgnoreCase)

	@("Create", "Edit", "Delete", "Details", "_CreateOrEdit") | %{
		Scaffold View -Controller $controllerNameWithoutSuffix -ViewName $_ -ModelType $ModelType -Template $_ -Area $Area -Layout $Layout -SectionNames $SectionNames -PrimarySectionName $PrimarySectionName -ReferenceScriptLibraries:$ReferenceScriptLibraries -Project $Project -CodeLanguage $CodeLanguage -OverrideTemplateFolders $TemplateFolders -Force:$Force -BlockUi
	}

	Scaffold Obsidian.Views.Grid -Controller $controllerNameWithoutSuffix -ModelType $ModelType -Area $Area -Layout $Layout -SectionNames $SectionNames -PrimarySectionName $PrimarySectionName -ReferenceScriptLibraries:$ReferenceScriptLibraries -Project $Project -CodeLanguage $CodeLanguage -OverrideTemplateFolders $TemplateFolders -Force:$Force -BlockUi
}