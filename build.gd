@tool
extends EditorPlugin

func _enter_tree():
	add_custom_type("GPlot", "Control", preload("src/GPlot.cs"), null)

func _exit_tree():
	remove_custom_type("GPlot")
