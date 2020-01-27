using L2ScriptMaker.Extensions.VbCompatibleHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L2ScriptMaker.Modules.Npc
{
	public partial class NpcposMap : Form
	{
		public NpcposMap()
		{
			InitializeComponent();
		}
	}

	static class l2_map_main
	{
		public const double map_multiplier = 133.5;
		public const int map_move_x = 987;
		public const int map_move_y = 1964;



		public static l2_map_info info;
	}

	public class l2_map_config
	{
		private string name_local;
		private string name_end_local;

		public string name
		{
			get
			{
				string nameRet = default(string);
				nameRet = name_local;
				return nameRet;
			}
		}
		public string name_end
		{
			get
			{
				string name_endRet = default(string);
				name_endRet = name_end_local;
				return name_endRet;
			}
		}

		private l2_map_config_parameter[] config_parameters_local;

		public int config_parameters_count
		{
			get
			{
				int config_parameters_countRet = default(int);
				config_parameters_countRet = config_parameters_local.GetUpperBound(0);
				return config_parameters_countRet;
			}
		}

		public l2_map_config_parameter[] config_parameters
		{
			get
			{
				l2_map_config_parameter[] config_parametersRet = default(l2_map_config_parameter[]);
				config_parametersRet = config_parameters_local;
				return config_parametersRet;
			}
		}

		private string name_to_display_local;

		public string name_to_display
		{
			get
			{
				string name_to_displayRet = default(string);
				name_to_displayRet = name_to_display_local;
				return name_to_displayRet;
			}
		}

		private l2_map_drawing_parameters drawing_parameters_local;
		public l2_map_drawing_parameters drawing_parameters
		{
			get
			{
				l2_map_drawing_parameters drawing_parametersRet = default(l2_map_drawing_parameters);
				drawing_parametersRet = drawing_parameters_local;
				return drawing_parametersRet;
			}
		}

		public l2_map_config(string[] s)
		{
			int i;
			var count_parameters = default(int);

			name_local = s[0].Substring(s[0].LastIndexOf("=") + 1);

			if (name_local.Contains(";"))
			{
				name_end_local = name_local.Substring(name_local.LastIndexOf(";") + 1);
				name_local = name_local.Substring(0, name_local.LastIndexOf(";"));
			}

			var loopTo = s.GetUpperBound(0);
			for (i = 1; i <= loopTo; i++)
			{
				s[i] = s[i].Replace(Conversions.ToString((char)9), "");
				if (s[i].StartsWith("display=") | s[i].StartsWith("draw="))
				{
				}
				else
					count_parameters = count_parameters + 1;
			}

			config_parameters_local = new l2_map_config_parameter[count_parameters + 1];

			count_parameters = 0;
			var loopTo1 = s.GetUpperBound(0);
			for (i = 1; i <= loopTo1; i++)
			{
				if (s[i].StartsWith("display="))
					name_to_display_local = s[i].Substring(s[i].LastIndexOf("=") + 1);
				else if (s[i].StartsWith("draw="))
					drawing_parameters_local = new l2_map_drawing_parameters(s[i]);
				else
				{
					count_parameters = count_parameters + 1;
					config_parameters_local[count_parameters] = new l2_map_config_parameter(s[i]);
				}
			}
		}
	}

	public class l2_map_config_parameter
	{
		private string position_local;

		public string position
		{
			get
			{
				string positionRet = default(string);
				positionRet = position_local;
				return positionRet;
			}
		}

		private string position_name_local;

		public string position_name
		{
			get
			{
				string position_nameRet = default(string);
				position_nameRet = position_name_local;
				return position_nameRet;
			}
		}



		public enum config_formats
		{
			empty = 10,
			empty_clear = 11,
			coordinates = 20,
			coordinate_pos = 30,
			obj_list = 40,
			coordinate = 50,
			list = 60,
			list_table = 70
		}

		private config_formats format_local;

		public config_formats format
		{
			get
			{
				config_formats formatRet = default(config_formats);
				formatRet = format_local;
				return formatRet;
			}
		}

		private config_formats format_from_string(string f)
		{
			config_formats format_from_stringRet = default(config_formats);
			f = f.Replace("format=", "");

			if (f.StartsWith("empty"))
			{
				if (f.Length == 5)
					format_from_stringRet = config_formats.empty;
				else
					format_from_stringRet = config_formats.empty_clear;
				return format_from_stringRet;
			}

			if (f.StartsWith("list_table"))
			{
				format_from_stringRet = config_formats.list_table;
				return format_from_stringRet;
			}
			else if (f.StartsWith("list"))
			{
				format_from_stringRet = config_formats.list;
				return format_from_stringRet;
			}

			if (f.StartsWith("obj_list"))
			{
				format_from_stringRet = config_formats.obj_list;
				return format_from_stringRet;
			}

			switch (f)
			{
				case "coordinates":
					{
						format_from_stringRet = config_formats.coordinates;
						break;
					}

				case "coordinate_pos":
					{
						format_from_stringRet = config_formats.coordinate_pos;
						break;
					}

				case "coordinate":
					{
						format_from_stringRet = config_formats.coordinate;
						break;
					}
			}

			return format_from_stringRet;
		}




		private string property_name_local;

		public string property_name
		{
			get
			{
				string property_nameRet = default(string);
				property_nameRet = property_name_local;
				return property_nameRet;
			}
		}



		private string[] coordinates_names_local = new string[6];

		public string[] coordinates_names
		{
			get
			{
				string[] coordinates_namesRet = default(string[]);
				coordinates_namesRet = coordinates_names_local;
				return coordinates_namesRet;
			}
		}

		private void create_coordinates_names(string s)
		{
			int i;
			string[] s2;

			s = s.Replace("names=", "");

			s2 = s.Split(Conversions.ToChar(","));
			var loopTo = s2.GetUpperBound(0);
			for (i = 0; i <= loopTo; i++)
				coordinates_names_local[i + 1] = s2[i];
		}



		private string[] list_names_local;

		private string separator_local;

		public string separator
		{
			get
			{
				string separatorRet = default(string);
				separatorRet = separator_local;
				return separatorRet;
			}
		}

		public string[] list_names
		{
			get
			{
				string[] list_namesRet = default(string[]);
				list_namesRet = list_names_local;
				return list_namesRet;
			}
		}

		private void create_list_names(string s)
		{
			int i;
			string[] s2;

			s = s.Replace("format=list_table", "");

			separator_local = Conversions.ToString(Conversions.ToChar(s.Substring(0, 1)));

			s = s.Substring(2, s.Length - 3);

			s2 = s.Split(Conversions.ToChar(","));

			list_names_local = new string[s2.GetUpperBound(0) + 1 + 1];
			var loopTo = s2.GetUpperBound(0);
			for (i = 0; i <= loopTo; i++)
				list_names_local[i + 1] = s2[i];
		}



		private string object_name_local;
		public string object_name
		{
			get
			{
				string object_nameRet = default(string);
				object_nameRet = object_name_local;
				return object_nameRet;
			}
		}

		private string object_id_local;

		public string object_id
		{
			get
			{
				string object_idRet = default(string);
				object_idRet = object_id_local;
				return object_idRet;
			}
		}

		private void create_object_parameters(string s)
		{
			string[] s2;

			s = s.Replace("format=obj_list(", "");
			s = s.Substring(0, s.Length - 1);

			s2 = s.Split(Conversions.ToChar(","));

			object_name_local = s2[0];
			object_id_local = s2[1];
		}


		public l2_map_config_parameter(string str)
		{
			string[] s;

			int start;

			str = str.Replace(Conversions.ToString((char)9), "");

			s = str.Split(Conversions.ToChar(";"));

			position_local = s[0].Substring(s[0].LastIndexOf("=") + 1);

			if ((position_local ?? "") == "any")
			{
				start = 1;
				position_name_local = s[1];
			}
			else
				start = 0;

			property_name_local = s[start + 1];

			format_local = format_from_string(s[start + 2]);

			switch (format_local)
			{
				case config_formats.empty | config_formats.empty_clear:
					{
						break;
					}

				case config_formats.coordinates:
					{
						create_coordinates_names(s[start + 3]);
						break;
					}

				case config_formats.coordinate:
					{
						create_coordinates_names(s[start + 3]);
						break;
					}

				case config_formats.coordinate_pos:
					{
						create_coordinates_names(s[start + 3]);
						break;
					}

				case config_formats.list_table:
					{
						create_list_names(s[start + 2]);
						break;
					}

				case config_formats.obj_list:
					{
						create_object_parameters(s[start + 2]);
						break;
					}
			}
		}
	}

	public class l2_map_drawing_object
	{
		private l2_map_drawing_parameters drawing_parameters_local;
		public l2_map_drawing_parameters drawing_parameters
		{
			get
			{
				l2_map_drawing_parameters drawing_parametersRet = default(l2_map_drawing_parameters);
				drawing_parametersRet = drawing_parameters_local;
				return drawing_parametersRet;
			}
		}


		private Point[] points_local = new Point[1];
		public Point[] points
		{
			get
			{
				Point[] pointsRet = default(Point[]);
				pointsRet = points_local;
				return pointsRet;
			}
		}

		public void add_point(int x, int y)
		{
			var oldPoints_local = points_local;
			points_local = new Point[points_local.GetUpperBound(0) + 1 + 1];
			if (oldPoints_local != null)
				Array.Copy(oldPoints_local, points_local, Math.Min(points_local.GetUpperBound(0) + 1 + 1, oldPoints_local.Length));
			points[points_local.GetUpperBound(0)] = 
				new Point(
					Conversions.ToInteger(x / l2_map_main.map_multiplier + l2_map_main.map_move_x),
					Conversions.ToInteger(y / l2_map_main.map_multiplier + l2_map_main.map_move_y)
					);
		}

		public l2_map_drawing_object(l2_map_drawing_parameters new_drawing_parameters)
		{
			drawing_parameters_local = new_drawing_parameters;
		}
	}

	public class l2_map_drawing_parameters
	{
		public enum drawing_types
		{
			points = 10,
			zone = 20
		}

		private Color color_local;
		public Color color
		{
			get
			{
				Color colorRet = default(Color);
				colorRet = color_local;
				return colorRet;
			}
		}

		private drawing_types drawing_type_local;
		public drawing_types drawing_type
		{
			get
			{
				drawing_types drawing_typeRet = default(drawing_types);
				drawing_typeRet = drawing_type_local;
				return drawing_typeRet;
			}
		}

		private int draw_width_local;

		public int draw_width
		{
			get
			{
				int draw_widthRet = default(int);
				draw_widthRet = draw_width_local;
				return draw_widthRet;
			}
		}

		private Color color_by_string(string str)
		{
			Color color_by_stringRet = default(Color);
			var a = new ColorConverter();

			try
			{
				color_by_stringRet = (Color)a.ConvertFromString(str);
			}
			catch (Exception ex)
			{
				color_by_stringRet = Color.Black;
			}

			return color_by_stringRet;
		}

		public l2_map_drawing_parameters(string str)
		{
			string[] s;

			str = str.Replace("draw=", "");

			s = str.Split(Conversions.ToChar(";"));

			if ((s[0] ?? "") == "zone")
				drawing_type_local = drawing_types.zone;
			else
				drawing_type_local = drawing_types.points;

			color_local = color_by_string(s[1]);

			draw_width_local = Conversions.ToInteger(s[2]);
		}
	}

	public class l2_map_file_string
	{
		public enum string_types
		{
			obj = 10,
			comment = 20,
			collection_start = 30,
			collection_end = 40
		}

		private string_types string_type_local;

		public string_types string_type
		{
			get
			{
				string_types string_typeRet = default(string_types);
				string_typeRet = string_type_local;
				return string_typeRet;
			}
		}



		private string str_local;
		public string str
		{
			get
			{
				string strRet = default(string);
				strRet = str_local;
				return strRet;
			}
		}


		private l2_map_file_string_property[] properties_local;
		public l2_map_file_string_property[] properties
		{
			get
			{
				l2_map_file_string_property[] propertiesRet = default(l2_map_file_string_property[]);
				propertiesRet = properties_local;
				return propertiesRet;
			}
		}


		private string object_name_local;

		public string object_name
		{
			get
			{
				string object_nameRet = default(string);
				object_nameRet = object_name_local;
				return object_nameRet;
			}
		}

		private string name_to_display_local;

		public string name_to_display
		{
			get
			{
				string name_to_displayRet = default(string);
				name_to_displayRet = name_to_display_local;
				return name_to_displayRet;
			}
		}


		private l2_map_drawing_object[] drawing_objects_local = new l2_map_drawing_object[1];
		public l2_map_drawing_object[] drawing_objects
		{
			get
			{
				l2_map_drawing_object[] drawing_objectsRet = default(l2_map_drawing_object[]);
				drawing_objectsRet = drawing_objects_local;
				return drawing_objectsRet;
			}
			set
			{
				drawing_objects_local = value;
			}
		}

		private l2_map_config config_used_local;
		public l2_map_config config_used
		{
			get
			{
				l2_map_config config_usedRet = default(l2_map_config);
				config_usedRet = config_used_local;
				return config_usedRet;
			}
		}


		public int[] obj_idx = new int[51];
		public int obj_idx_count;
		public bool is_indexed = false;




		public l2_map_file_string(string file_string, l2_map_config[] configs)
		{
			int i;
			string[] s;

			int config_num = 0;

			int end_property_num;

			str_local = file_string;
			str_local = file_string.Replace("    ", Conversions.ToString((char)9));

			s = str_local.Split((char)9);

			string_type_local = 0;
			var loopTo = configs.GetUpperBound(0);
			for (i = 1; i <= loopTo; i++)
			{
				if ((configs[i].name ?? "") == (s[0] ?? ""))
				{
					if (!string.IsNullOrEmpty(configs[i].name_end))
						string_type_local = string_types.collection_start;
					else
						string_type_local = string_types.obj;
					config_num = i;
					break;
				}
				if (!string.IsNullOrEmpty(configs[i].name_end))
				{
					if (s[0].StartsWith(configs[i].name_end))
					{
						string_type_local = string_types.collection_end;
						config_num = i;
					}
				}
			}

			if (string_type_local == 0)
				string_type_local = string_types.comment;

			if ((int)string_type_local == (int)string_types.collection_end)
				object_name_local = configs[config_num].name_end;
			else if ((int)string_type_local == (int)string_types.comment)
				object_name_local = str_local;
			else
			{
				var withBlock = configs[config_num];
				config_used_local = configs[config_num];

				end_property_num = 0;
				var loopTo1 = s.GetUpperBound(0);
				for (i = 1; i <= loopTo1; i++)
				{
					if (s[i].Length > 0)
						end_property_num = end_property_num + 1;
				}

				if (string.IsNullOrEmpty(withBlock.name_end))
					end_property_num = end_property_num - 1;
				else
					end_property_num = end_property_num;

				properties_local = new l2_map_file_string_property[end_property_num + 1];
				var loopTo2 = end_property_num;
				for (i = 1; i <= loopTo2; i++)
					properties_local[i] = new l2_map_file_string_property(s[i], i + 1, configs[config_num]);
				var loopTo3 = properties_local.GetUpperBound(0);
				for (i = 1; i <= loopTo3; i++)
				{
					if ((withBlock.name_to_display ?? "") == (properties_local[i].config_name ?? ""))
					{
						object_name_local = properties_local[i].simple_name;
						name_to_display_local = withBlock.name + " - " + properties_local[i].simple_name;
						break;
					}
				}
			}
		}
	}

	public class l2_map_file_string_property
	{
		public enum file_string_properties_types
		{
			simple = 10,
			simple_with_name = 20,
			empty = 30,
			empty_clear = 40,
			obj_list = 50,
			list = 60,
			list_table = 70,
			coordinate = 80
		}

		private file_string_properties_types property_type_local;

		public file_string_properties_types property_type
		{
			get
			{
				file_string_properties_types property_typeRet = default(file_string_properties_types);
				property_typeRet = property_type_local;
				return property_typeRet;
			}
		}



		private string simple_name_local;
		private string simple_value_local;

		public string simple_name
		{
			get
			{
				string simple_nameRet = default(string);
				simple_nameRet = simple_name_local;
				return simple_nameRet;
			}
			set
			{
				simple_name_local = value;
			}
		}

		public string simple_value
		{
			get
			{
				string simple_valueRet = default(string);
				simple_valueRet = simple_value_local;
				return simple_valueRet;
			}
			set
			{
				simple_value_local = value;
			}
		}



		private string[] obj_list_local;
		public string[] obj_list
		{
			get
			{
				string[] obj_listRet = default(string[]);
				obj_listRet = obj_list_local;
				return obj_listRet;
			}
			set
			{
				obj_list_local = value;
			}
		}

		private void create_obj_list(string str)
		{
			string[] s;
			s = str.Split(Conversions.ToChar(";"));
			obj_list_local = new string[s.GetUpperBound(0) + 1 + 1];
			obj_list_indexes = new int[s.GetUpperBound(0) + 1 + 1];
			for (int i = 0, loopTo = s.GetUpperBound(0); i <= loopTo; i++)
				obj_list_local[i + 1] = s[i].Substring(1, s[i].Length - 2);
		}

		public int[] obj_list_indexes;

		private string obj_list_str_type_local;
		public string obj_list_str_type
		{
			get
			{
				string obj_list_str_typeRet = default(string);
				obj_list_str_typeRet = obj_list_str_type_local;
				return obj_list_str_typeRet;
			}
		}



		private string[] list_local;
		public string[] list
		{
			get
			{
				string[] listRet = default(string[]);
				listRet = list_local;
				return listRet;
			}
			set
			{
				list_local = value;
			}
		}

		private void create_list(string str)
		{
			int i;
			string[] s;

			str = str.Substring(str.IndexOf("=") + 2);
			str = str.Substring(0, str.Length - 1);

			s = str.Split(Conversions.ToChar(";"));
			list_local = new string[s.GetUpperBound(0) + 1 + 1];
			var loopTo = s.GetUpperBound(0);
			for (i = 0; i <= loopTo; i++)
				list_local[i + 1] = s[i];
		}



		private string[] list_table_names_local;
		private string[,] table_local;

		public string[] list_table_names
		{
			get
			{
				string[] list_table_namesRet = default(string[]);
				list_table_namesRet = list_table_names_local;
				return list_table_namesRet;
			}
		}

		public string[,] table
		{
			get
			{
				string[,] tableRet = default(string[,]);
				tableRet = table_local;
				return tableRet;
			}
			set
			{
				table_local = value;
			}
		}

		public void create_table(string str, l2_map_config_parameter config)
		{
			string[] s;
			string[] s2;
			int i;
			int j;

			list_table_names_local = config.list_names;

			str = str.Substring(str.IndexOf("=") + 1);
			str = str.Substring(1, str.Length - 2);

			s = str.Split(Conversions.ToChar(";"));

			table_local = new string[list_table_names_local.GetUpperBound(0) + 1, s.GetUpperBound(0) + 1 + 1];
			var loopTo = s.GetUpperBound(0);
			for (i = 0; i <= loopTo; i++)
			{
				s2 = s[i].Split(Conversions.ToChar(config.separator));
				var loopTo1 = s2.GetUpperBound(0);
				for (j = 0; j <= loopTo1; j++)
					table_local[j + 1, i + 1] = s2[j];
			}
		}



		private string config_name_local;

		public string config_name
		{
			get
			{
				string config_nameRet = default(string);
				config_nameRet = config_name_local;
				return config_nameRet;
			}
		}



		private string pos_local;
		private int points_count_local;

		private point[] points_local;

		public struct point
		{
			internal int x;
			internal int y;
			internal int z;
			internal int z2;
			internal string percent;
		}

		private bool anywhere_local;

		public bool anywhere
		{
			get
			{
				bool anywhereRet = default(bool);
				anywhereRet = anywhere_local;
				return anywhereRet;
			}
		}


		private void create_coordinate(string str)
		{
			string[] s1;
			string[] s2;
			int i;
			int j;

			if (str.StartsWith("pos="))
			{
				pos_local = "pos=";
				str = str.Substring(4);
			}
			else
				pos_local = "";

			if (str.StartsWith("{{"))
			{
				str = str.Substring(1, str.Length - 2);
				if ((str.Substring(str.Length - 2) ?? "") == "}}")
					str = str.Substring(0, str.Length - 1);
				s2 = str.Split(Conversions.ToChar("};"));
				s1 = new string[s2.GetUpperBound(0) - 1 + 1];
				var loopTo = s2.GetUpperBound(0) - 1;
				for (i = 0; i <= loopTo; i++)
				{
					s1[i] = s2[i];
					if (s1[i].StartsWith(";"))
						s1[i] = s1[i].Substring(1);
				}
			}
			else
			{
				s1 = new string[1];
				s1[0] = str.Replace("}", "");
			}

			points_count_local = s1.GetUpperBound(0) + 1;

			points_local = new point[points_count_local + 1];
			var loopTo1 = points_count_local - 1;
			for (i = 0; i <= loopTo1; i++)
			{
				s2 = s1[i].Replace("{", "").Split(Conversions.ToChar(";"));

				if ((s2[0] ?? "") == "anywhere")
					anywhere_local = true;
				else
				{
					anywhere_local = false;
					points_local[i + 1].x = Conversions.ToInteger(s2[0]);
					points_local[i + 1].y = Conversions.ToInteger(s2[1]);
					points_local[i + 1].z = Conversions.ToInteger(s2[2]);
					points_local[i + 1].z2 = Conversions.ToInteger(s2[3]);
					if (s2.GetUpperBound(0) > 3)
						points_local[i].percent = s2[4];
				}
			}
		}

		public int points_count
		{
			get
			{
				int points_countRet = default(int);
				points_countRet = points_count_local;
				return points_countRet;
			}
		}

		public point[] points
		{
			get
			{
				point[] pointsRet = default(point[]);
				pointsRet = points_local;
				return pointsRet;
			}
			set
			{
				points_local = value;
			}
		}

		public string get_point_string(int index)
		{
			string point_stringRet = default(string);
			point_stringRet = Conversions.ToString(points_local[index].x) + ", " + Conversions.ToString(points_local[index].y) + ", " + Conversions.ToString(points_local[index].z) + ", " + Conversions.ToString(points[index].z2);
			if (!string.IsNullOrEmpty(points_local[index].percent))
				point_stringRet = point_stringRet + points_local[index].percent;
			return point_stringRet;
		}



		private l2_map_config_parameter config_parameter_local;

		public l2_map_config_parameter config_parameter
		{
			get
			{
				l2_map_config_parameter config_parameterRet = default(l2_map_config_parameter);
				config_parameterRet = config_parameter_local;
				return config_parameterRet;
			}
		}


		public l2_map_file_string_property(string str, int property_num, l2_map_config config)
		{
			int rule_num;
			int i;

			rule_num = 0;
			{
				var withBlock = config;
				var loopTo = withBlock.config_parameters_count;
				for (i = 1; i <= loopTo; i++)
				{
					if ((withBlock.config_parameters[i].position ?? "") == "any")
					{
						if (str.Contains("="))
						{
							if ((str.Substring(0, str.LastIndexOf("=")) ?? "") == (withBlock.config_parameters[i].position_name ?? ""))
							{
								rule_num = i;
								break;
							}
						}
					}
					else if (Conversions.ToInteger(withBlock.config_parameters[i].position) == property_num)
					{
						rule_num = i;
						break;
					}
				}
			}

			if (rule_num > 0)
			{
				config_parameter_local = config.config_parameters[rule_num];

				{
					var withBlock1 = config.config_parameters[rule_num];
					config_name_local = withBlock1.property_name;

					switch (withBlock1.format)
					{
						case l2_map_config_parameter.config_formats.empty:
							{
								property_type_local = file_string_properties_types.empty;
								simple_name_local = str;
								break;
							}

						case l2_map_config_parameter.config_formats.empty_clear:
							{
								property_type_local = file_string_properties_types.empty_clear;
								simple_name_local = str.Substring(1, str.Length - 2);
								break;
							}

						case l2_map_config_parameter.config_formats.obj_list:
							{
								property_type_local = file_string_properties_types.obj_list;
								obj_list_str_type_local = withBlock1.object_name;
								create_obj_list(str);
								var loopTo1 = obj_list_local.GetUpperBound(0);
								for (i = 1; i <= loopTo1; i++)
								{
									simple_name_local = simple_name_local + obj_list_local[i];
									if (i < obj_list_local.GetUpperBound(0))
										simple_name_local = simple_name_local + ";";
								}
								simple_name_local = simple_name_local;
								break;
							}

						case l2_map_config_parameter.config_formats.list:
							{
								property_type_local = file_string_properties_types.list;
								simple_name_local = str.Substring(0, str.LastIndexOf("="));
								create_list(str);
								break;
							}

						case l2_map_config_parameter.config_formats.list_table:
							{
								property_type_local = file_string_properties_types.list_table;
								create_table(str, config.config_parameters[rule_num]);
								simple_name_local = str.Substring(0, str.IndexOf("="));
								break;
							}

						case l2_map_config_parameter.config_formats.coordinate:
							{
								property_type_local = file_string_properties_types.coordinate;
								create_coordinate(str);
								if (anywhere_local == true)
									simple_name_local = "coordinates = anywhere";
								else
									simple_name_local = "coordinates (" + Conversions.ToString(points_count_local) + ")";
								break;
							}
					}
				}
			}

			if (rule_num == 0)
			{

				// If str.Contains("=") Then
				// property_type_local = file_string_properties_types.simple_with_name
				// simple_value_local = str.Substring(str.LastIndexOf("=") + 1)
				// simple_name_local = str.Substring(0, str.LastIndexOf("="))
				// Else
				property_type_local = file_string_properties_types.simple;
				simple_name_local = str;
			}
		}
	}

	public class l2_map_info
	{
		private string config_path_local;

		private string[] config_local;

		public string config_path
		{
			get
			{
				string config_pathRet = default(string);
				config_pathRet = config_path_local;
				return config_pathRet;
			}
			set
			{
				config_path_local = value;
				load_config(value);
			}
		}

		private l2_map_config[] configs;

		private void load_config(string path)
		{
			System.IO.StreamReader F;
			string Str;

			int str_count = 0;
			int config_start = 0;

			string[] config;

			int i;

			config_local = new string[1];

			configs = new l2_map_config[1];

			F = System.IO.File.OpenText(path);
			while (!F.EndOfStream)
			{
				Str = F.ReadLine();
				str_count = str_count + 1;
				var oldConfig_local = config_local;
				config_local = new string[str_count + 1];
				if (oldConfig_local != null)
					Array.Copy(oldConfig_local, config_local, Math.Min(str_count + 1, oldConfig_local.Length));
				config_local[str_count] = Str;

				if (Str.StartsWith("type"))
					config_start = str_count;

				if (Str.StartsWith("end_type"))
				{
					if (config_start > 0)
					{
						config = new string[1];
						var loopTo = str_count - 1;
						for (i = config_start; i <= loopTo; i++)
						{
							config[config.GetUpperBound(0)] = config_local[i];
							if (i < str_count - 1)
							{
								var oldConfig = config;
								config = new string[config.GetUpperBound(0) + 1 + 1];
								if (oldConfig != null)
									Array.Copy(oldConfig, config, Math.Min(config.GetUpperBound(0) + 1 + 1, oldConfig.Length));
							}
						}

						var oldConfigs = configs;
						configs = new l2_map_config[configs.GetUpperBound(0) + 1 + 1];
						if (oldConfigs != null)
							Array.Copy(oldConfigs, configs, Math.Min(configs.GetUpperBound(0) + 1 + 1, oldConfigs.Length));
						configs[configs.GetUpperBound(0)] = new l2_map_config(config);

						config_start = 0;
					}
				}
			}
		}



		private string file_path_local;

		private l2_map_file_string[] file_strings_local;

		public string file_path
		{
			get
			{
				string file_pathRet = default(string);
				file_pathRet = file_path_local;
				return file_pathRet;
			}
			set
			{
				load_file(value);

				file_path_local = value;
			}
		}

		private void add_drawing_parameters(int str_num, l2_map_file_string obj = null)
		{
			int k;

			if (obj == null)
				obj = file_strings_local[str_num];
			var loopTo = obj.properties.GetUpperBound(0);
			for (k = 1; k <= loopTo; k++)
			{
				if ((int)obj.properties[k].property_type == (int)l2_map_file_string_property.file_string_properties_types.coordinate)
				{
					if (obj.properties[k].anywhere == true)
					{
					}
					else
					{
						// ReDim Preserve file_strings_local(str_num).drawing_objects(file_strings_local(str_num).drawing_objects.GetUpperBound(0) + 1)

						// !!!!!!!!!!!! fucking magic. must checking, must refactoring, must destroy
						l2_map_drawing_object[] oldFile_strings_local = file_strings_local[str_num].drawing_objects;
						file_strings_local[str_num].drawing_objects = new l2_map_drawing_object[file_strings_local[str_num].drawing_objects.GetUpperBound(0) + 1 + 1];
						if (oldFile_strings_local != null)
							Array.Copy(oldFile_strings_local,
								file_strings_local[str_num].drawing_objects,
								Math.Min(file_strings_local[str_num].drawing_objects.GetUpperBound(0) + 1 + 1,
									oldFile_strings_local.Length));
						// !!!!!!!!!!!! 

						file_strings_local[str_num].drawing_objects[file_strings_local[str_num].drawing_objects.GetUpperBound(0)] = new l2_map_drawing_object(obj.config_used.drawing_parameters);

						var withBlock = obj.properties[k];
						for (int m = 1, loopTo1 = withBlock.points.GetUpperBound(0); m <= loopTo1; m++)
							file_strings_local[str_num].drawing_objects[file_strings_local[str_num].drawing_objects.GetUpperBound(0)].add_point(withBlock.points[m].x, withBlock.points[m].y);
					}
				}
			}
		}

		private void load_file(string path)
		{
			System.IO.StreamReader F;
			string Str;
			var file_str_count = default(int);
			bool founded;
			int flag_space;
			int i;
			int j;
			int k;
			int m;

			// Падщот строк файла
			F = System.IO.File.OpenText(path);
			while (!F.EndOfStream)
			{
				Str = F.ReadLine();
				file_str_count = file_str_count + 1;
			}
			F.Close();

			file_strings_local = new l2_map_file_string[file_str_count + 1];
			file_str_count = 0;

			// Загрузка файла
			F = System.IO.File.OpenText(path);
			while (!F.EndOfStream)
			{
				Str = F.ReadLine();

				// Убираем пробелы, идущие подряд по несколько штук
				flag_space = Str.Length;
				// Str = Str.Replace(Chr(9), " ")
				while (1 == 1)
				{
					Str = Str.Replace("  ", " ");
					if (Str.Length == flag_space)
						break;
					else
						flag_space = Str.Length;
				}
				Str = Str.Replace(" ", Conversions.ToString((char)9));

				file_str_count = file_str_count + 1;
				file_strings_local[file_str_count] = new l2_map_file_string(Str, configs);
			}
			F.Close();
			var loopTo = file_str_count;

			// Индексация ссылок на другие объекты (obj_list)
			for (i = 1; i <= loopTo; i++)
			{
				if ((int)file_strings_local[i].string_type == (int)l2_map_file_string.string_types.obj | (int)file_strings_local[i].string_type == (int)l2_map_file_string.string_types.collection_start)
				{
					var loopTo1 = file_strings_local[i].properties.GetUpperBound(0);
					for (j = 1; j <= loopTo1; j++)
					{
						if ((int)file_strings_local[i].properties[j].property_type == (int)l2_map_file_string_property.file_string_properties_types.obj_list)
						{
							var loopTo2 = file_strings_local[i].properties[j].obj_list_indexes.GetUpperBound(0);
							for (m = 1; m <= loopTo2; m++)
							{
								founded = false;
								for (k = i - 1; k >= 1; k += -1)
								{
									var obj1 = file_strings_local[i];
									var obj2 = file_strings_local[k];
									if ((int)obj2.string_type == (int)l2_map_file_string.string_types.obj)
									{
										if ((obj1.properties[j].obj_list_str_type ?? "") == (obj2.config_used.name ?? ""))
										{
											if ((file_strings_local[k].object_name ?? "") == (file_strings_local[i].properties[j].obj_list[m] ?? ""))
											{
												file_strings_local[i].properties[j].obj_list_indexes[m] = k;
												founded = true;
												break;
											}
										}
									}
								}
								if (founded == false)
								{
									var loopTo3 = file_str_count;
									for (k = i; k <= loopTo3; k++)
									{
										var obj1 = file_strings_local[i];
										var obj2 = file_strings_local[k];
										if ((int)obj2.string_type == (int)l2_map_file_string.string_types.obj)
										{
											if ((obj1.properties[j].obj_list_str_type ?? "") == (obj2.config_used.name ?? ""))
											{
												if ((file_strings_local[k].object_name ?? "") == (file_strings_local[i].properties[j].obj_list[m] ?? ""))
												{
													file_strings_local[i].properties[j].obj_list_indexes[m] = k;
													founded = true;
													break;
												}
											}
										}
									}
								}
								founded = true;
							}
						}
					}
				}
			}

			var loopTo4 = file_str_count;

			// Создание объектов прорисовки
			for (i = 1; i <= loopTo4; i++)
			{

				// индексировано => нахуй
				// If file_strings_local(i).string_type = l2_map_file_string.string_types.collection_start Or file_strings_local(i).string_type = l2_map_file_string.string_types.obj Then
				// For j = 1 To file_strings_local(i).properties.GetUpperBound(0)
				// If file_strings_local(i).properties(j).property_type = l2_map_file_string_property.file_string_properties_types.obj_list Then
				// For k = 1 To file_strings_local(i).properties(j).obj_list_indexes.GetUpperBound(0)
				// add_drawing_parameters(i, file_strings_local(file_strings_local(i).properties(j).obj_list_indexes(k)))
				// Next
				// End If
				// Next
				// End If

				if ((int)file_strings_local[i].string_type == (int)l2_map_file_string.string_types.collection_start)
				{
					add_drawing_parameters(i);
					var loopTo5 = file_str_count;
					for (j = i + 1; j <= loopTo5; j++)
					{
						if ((int)file_strings_local[j].string_type == (int)l2_map_file_string.string_types.collection_end)
							break;
						
						// #error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
						/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 80299
						   at ICSharpCode.CodeConverter.CSharp.MethodBodyExecutableStatementVisitor.<DefaultVisit>d__24.MoveNext()
						--- End of stack trace from previous location where exception was thrown ---
						   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
						   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
						   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<CreateLocals>d__7.MoveNext()
						--- End of stack trace from previous location where exception was thrown ---
						   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
						   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
						   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<AddLocalVariables>d__6.MoveNext()
						--- End of stack trace from previous location where exception was thrown ---
						   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
						   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
						   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<ConvertWithTrivia>d__4.MoveNext()
						--- End of stack trace from previous location where exception was thrown ---
						   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
						   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
						   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisit>d__3.MoveNext()

						Input: 

											On Error Resume Next

						 */
						try
						{
							add_drawing_parameters(i, file_strings_local[j]);
						}
						catch
						{
							continue;
						}
					}
				}

				if ((int)file_strings_local[i].string_type == (int)l2_map_file_string.string_types.obj)
					add_drawing_parameters(i);
			}

			int u_bound;
			int u_bound_2;
			var loopTo6 = file_strings_local.GetUpperBound(0);

			// Индексация ссылок на объект
			// For i = 1 To file_strings_local.GetUpperBound(0)
			// If file_strings_local(i).string_type = l2_map_file_string.string_types.collection_start Or file_strings_local(i).string_type = l2_map_file_string.string_types.obj Then

			// For j = 1 To file_strings_local(i).properties.GetUpperBound(0)

			// If file_strings_local(i).properties(j).property_type = l2_map_file_string_property.file_string_properties_types.obj_list Then

			// u_bound = file_strings_local(i).properties(j).obj_list_indexes.GetUpperBound(0)

			// If u_bound = 1 Then
			// u_bound_2 = file_strings_local(file_strings_local(i).properties(j).obj_list_indexes(1)).obj_idx.GetUpperBound(0)
			// ReDim Preserve file_strings_local(file_strings_local(i).properties(j).obj_list_indexes(1)).obj_idx(u_bound_2 + 1)
			// file_strings_local(file_strings_local(i).properties(j).obj_list_indexes(1)).obj_idx(u_bound_2) = i
			// End If

			// End If

			// Next

			// End If
			// Next

			// Dim num_idx(file_strings_local.GetUpperBound(0)) As Integer


			// For i = 1 To file_strings_local.GetUpperBound(0)
			// If file_strings_local(i).string_type = l2_map_file_string.string_types.collection_start Or file_strings_local(i).string_type = l2_map_file_string.string_types.obj Then

			// For j = 1 To file_strings_local(i).properties.GetUpperBound(0)

			// If file_strings_local(i).properties(j).property_type = l2_map_file_string_property.file_string_properties_types.obj_list Then

			// u_bound = file_strings_local(i).properties(j).obj_list_indexes.GetUpperBound(0)

			// If u_bound = 1 Then
			// num_idx(file_strings_local(i).properties(j).obj_list_indexes(1)) = num_idx(file_strings_local(i).properties(j).obj_list_indexes(1)) + 1
			// End If

			// End If

			// Next

			// End If
			// Next

			// For i = 1 To file_strings_local.GetUpperBound(0)
			// If num_idx(i) > 0 Then
			// ReDim file_strings_local(file_strings_local(i).properties(j).obj_list_indexes(1)).obj_idx(num_idx(i))
			// End If
			// num_idx(i) = 0
			// Next

			for (i = 1; i <= loopTo6; i++)
			{
				if ((int)file_strings_local[i].string_type == (int)l2_map_file_string.string_types.collection_start | (int)file_strings_local[i].string_type == (int)l2_map_file_string.string_types.obj)
				{
					var loopTo7 = file_strings_local[i].properties.GetUpperBound(0);
					for (j = 1; j <= loopTo7; j++)
					{
						if ((int)file_strings_local[i].properties[j].property_type == (int)l2_map_file_string_property.file_string_properties_types.obj_list)
						{
							u_bound = file_strings_local[i].properties[j].obj_list_indexes.GetUpperBound(0);

							if (u_bound == 1)
							{
								file_strings_local[i].is_indexed = true;
								file_strings_local[file_strings_local[i].properties[j].obj_list_indexes[1]].obj_idx_count = file_strings_local[file_strings_local[i].properties[j].obj_list_indexes[1]].obj_idx_count + 1;
								file_strings_local[file_strings_local[i].properties[j].obj_list_indexes[1]].obj_idx[file_strings_local[file_strings_local[i].properties[j].obj_list_indexes[1]].obj_idx_count] = i;
							}
						}
					}
				}
			}
		}




		public l2_map_file_string[] file_strings
		{
			get
			{
				l2_map_file_string[] file_stringsRet = default(l2_map_file_string[]);
				file_stringsRet = file_strings_local;
				return file_stringsRet;
			}
		}
	}
}
