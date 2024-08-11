@tool
extends EditorPlugin

func _enter_tree():
	add_custom_type("GDPlot", "Control", preload("src/GDPlot.cs"), null)

func _exit_tree():
	remove_custom_type("GDPlot")
