<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1140226)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# WPF Data Grid - How To Customize Cell Template

This example demonstrates how to create a custom cell template for a column of GridControl. It includes DataTemplates for image and button columns.

## Implementation details

In this DataTemplate, the image source depends on the `IsRead` property of a source element:

```xml
<DataTemplate x:Key="ImageCellTemplate">
    <Image>
        <Image.Style>
            <Style TargetType="Image">
                <Setter Property="Source"
                        Value="{dx:DXImage 'SvgImages/Icon Builder/Actions_EnvelopeClose.svg'}"/>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Row.IsRead}" Value="True">
                        <Setter Property="Source"
                                Value="{dx:DXImage 'SvgImages/Icon Builder/Actions_EnvelopeOpen.svg'}"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Image.Style>
    </Image>
</DataTemplate>
```

The template with a button also depends on the same property. If it is false, the button is disabled:

```xaml
<DataTemplate x:Key="ButtonCellTemplate">
    <dx:SimpleButton Content="Delete"
                     Command="{Binding DataContext.RemoveRowCommand, RelativeSource={RelativeSource AncestorType=dxg:GridControl}}"
                     CommandParameter="{Binding Row}"
                     IsEnabled="{Binding Row.IsRead}"/>
</DataTemplate>
```


## Documentation

- [CellTemplate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.CellTemplate)


## Files to Review
- [MainWindow.xaml](./CS/GridControlCellTemplate/MainWindow.xaml)
