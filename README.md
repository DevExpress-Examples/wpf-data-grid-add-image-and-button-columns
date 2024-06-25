<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/589446796/22.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1140226)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# WPF Data Grid - Add Image and Button Columns

This example displays columns filled with [Image](https://learn.microsoft.com/en-us/dotnet/api/system.windows.controls.image) and [SimpleButton](https://docs.devexpress.com/WPF/DevExpress.Xpf.Core.SimpleButton) objects in the [GridControl](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl). To specify custom content in grid cells, create a DataTemplate and assign it to the [ColumnBase.CellTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.CellTemplate) property.

![image](https://user-images.githubusercontent.com/65009440/212686679-52ebddc2-52bb-4b8b-81ab-b731606c5dab.png)

## Implementation details

The image template displays different images based on the `IsRead` property of the data object:

```xaml
<DataTemplate x:Key="ImageCellTemplate">
    <Image x:Name="MyIcon" 
           Source="{dx:DXImage 'SvgImages/Icon Builder/Actions_EnvelopeClose.svg'}"/>
    <DataTemplate.Triggers>
        <DataTrigger Binding="{Binding Row.IsRead}" Value="True">
            <Setter TargetName="MyIcon" 
                    Property="Source" 
                    Value="{dx:DXImage 'SvgImages/Icon Builder/Actions_EnvelopeOpen.svg'}"/>
        </DataTrigger>
    </DataTemplate.Triggers>
</DataTemplate>
```

The button template also depends on the `IsRead` property. If it is `false`, the button is disabled:

```xaml
<DataTemplate x:Key="ButtonCellTemplate">
    <dx:SimpleButton Content="Delete"
                     Command="{Binding DataContext.RemoveRowCommand, RelativeSource={RelativeSource AncestorType=dxg:GridControl}}"
                     CommandParameter="{Binding Row}"
                     IsEnabled="{Binding Row.IsRead}"/>
</DataTemplate>
```

## Files to Review

- [MainWindow.xaml](./CS/GridControlCellTemplate/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/GridControlCellTemplate/MainWindow.xaml))
- [MainViewModel.cs](./CS/GridControlCellTemplate/MainViewModel.cs) (VB: [MainViewModel.vb](./VB/GridControlCellTemplate/MainViewModel.vb))
- [ReadOnSelectionBehavior.cs](./CS/GridControlCellTemplate/Helpers/ReadOnSelectionBehavior.cs) (VB: [ReadOnSelectionBehavior.vb](./VB/GridControlCellTemplate/Helpers/ReadOnSelectionBehavior.vb))

## Documentation

- [CellTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.CellTemplate)
- [Assign Editors to Cells](https://docs.devexpress.com/WPF/401011/controls-and-libraries/data-grid/data-editing-and-validation/modify-cell-values/assign-an-editor-to-a-cell)

## More Examples

* [Build Binding Paths in WPF Data Grid Cells](https://github.com/DevExpress-Examples/how-to-build-binding-paths-in-gridcontrol-cells)
* [WPF Data Grid - Assign a ComboBox Editor to a Column](https://github.com/DevExpress-Examples/wpf-data-grid-assign-combobox-editor-to-column)
* [WPF Data Grid - Use Custom Editors to Edit Cell Values](https://github.com/DevExpress-Examples/how-to-use-custom-editors-to-edit-cell-values-e1596)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-data-grid-add-image-and-button-columns&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-data-grid-add-image-and-button-columns&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
