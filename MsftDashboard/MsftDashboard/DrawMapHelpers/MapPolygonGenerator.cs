using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Maps.MapControl;
using System.Windows.Media;
using MsftDashboard.DrawMapHelpers;
using System.Collections.ObjectModel;
using MsftDashboard.Models;
using System.Windows.Controls;
using System.Windows;

namespace MsftDashboard.DrawMapHelpers
{
    public class MapPolygonGenerator
    {
        private static List<StateShape> listStates = new List<StateShape>();
        private static int Elevemos = 0;

        private static Dictionary<string, string[]> StatesPoligonsDictionary= StateCoordinate.getDictionaryStates();

        //public static ObservableCollection<StatePivotShape> GetStatePivotMap()
        //{
        //    ObservableCollection<StatePivotShape> pivotState = new ObservableCollection<StatePivotShape>();

        //    Dictionary<string, string[]> dictionary = new StateCoordinate().getDictionaryStates();
        //    int i = 1;
        //    foreach (KeyValuePair<string, string[]> entry in dictionary)
        //    {
        //        StatePivotShape stateToAdd = getPolygonPivot(entry);
        //        stateToAdd.IdState = i;
        //        pivotState.Add(stateToAdd);
        //        i++;
        //    }

        //    return pivotState;
        //}


        //public static ObservableCollection<StateShapeElevemosMexico> GetStateElevemosMap()
        //{
        //    ObservableCollection<StateShapeElevemosMexico> elevemosState = new ObservableCollection<StateShapeElevemosMexico>();

        //    Dictionary<string, string[]> dictionary = new StateCoordinate().getDictionaryStates();
        //    int i = 1;
        //    foreach (KeyValuePair<string, string[]> entry in dictionary)
        //    {
        //        StateShapeElevemosMexico stateToAdd = getPolygonElevemos(entry);
        //        stateToAdd.IdState = i;
        //        elevemosState.Add(stateToAdd);
        //        i++;
        //    }

        //    return elevemosState;
        //}


        public static StateShape GetStatePolygon(string key)
        {
            
            string[] locations = StatesPoligonsDictionary[key];
            StateShape stateShape = getPolygonState(key, locations);
            return stateShape;

        }

        private static StateShape getPolygonState(string stateName, string[] locationsArray)
        {
            StateShape stateShape = new StateShape();
            stateShape.StateName = stateName;
            stateShape.Stroke = new SolidColorBrush(Color.FromArgb(100, 65, 177, 255));
            stateShape.StrokeThickness = 3;
            LocationCollection locations = parseCoordinatesLocation(locationsArray);
            stateShape.Locations = locations;

            return stateShape;
        }
           
        
        //public List<StateShape> getMapPolygonList()
        //{
        //    Dictionary<string, string[]> dictionary = new StateCoordinate().getDictionaryStates();
        //    int i = 1;
        //    foreach (KeyValuePair<string, string[]> entry in dictionary)
        //    {
        //        StateShape stateToAdd = getPolygonState(entry);
        //        stateToAdd.IdState = i;
        //        listStates.Add(stateToAdd);
        //        i++;
        //    }

        //    return listStates;
        //}

        //private static StateShape getPolygonState(KeyValuePair<string, string[]> entry)
        //{
        //    StateShape stateShape = new StateShape();

        //    stateShape.Title = entry.Key as string;
        //    string[] coordinates = entry.Value as string[];

        //    stateShape.Stroke = new SolidColorBrush(Color.FromArgb(100, 65, 177, 255));
        //    stateShape.StrokeThickness = 3;
        //    stateShape.Opacity = 0;
        //    stateShape.Fill = new SolidColorBrush(Color.FromArgb(100, 22, 157, 243));
        //    stateShape.Fill.Opacity = 0;
        //    //VERDE Color.FromArgb(150, 105, 177, 48)
        //    //Amarillo Color.FromArgb(100,241,251,10));
        //    //Rojo Color.FromArgb(100,251,10,10)
        //    //Gris Color.FromArgb(100,128,128,128)
        //    //Selected Azul Color.FromArgb(100,0,197,255)
        //    //stateShape.Fill.Opacity = 1;

        //    LocationCollection locations = parseCoordinatesLocation(coordinates);
        //    stateShape.Locations = locations;

        //    return stateShape;
        //}

        //private static StatePivotShape getPolygonPivot(KeyValuePair<string, string[]> entry)
        //{
        //    StatePivotShape stateShape = new StatePivotShape();

        //    stateShape.StateName = entry.Key as string;
        //    string[] coordinates = entry.Value as string[];
        //    stateShape.Stroke = new SolidColorBrush(Color.FromArgb(100, 65, 177, 255));
        //    stateShape.StrokeThickness = 3;
        //    stateShape.Opacity = 0;
        //    LocationCollection locations = parseCoordinatesLocation(coordinates);
        //    stateShape.Locations = locations;

        //    return stateShape;
        //}


        //private static StateShapeElevemosMexico getPolygonElevemos(KeyValuePair<string, string[]> entry)
        //{
        //    StateShapeElevemosMexico stateShape = new StateShapeElevemosMexico();

        //    stateShape.StateName = entry.Key as string;
        //    string[] coordinates = entry.Value as string[];
        //    stateShape.Stroke = new SolidColorBrush(Color.FromArgb(100, 65, 177, 255));
        //    stateShape.StrokeThickness = 3;
        //    stateShape.Opacity = 0;
        //    LocationCollection locations = parseCoordinatesLocation(coordinates);
        //    stateShape.Locations = locations;

        //    return stateShape;
        //}

        //private static StateShapePolitical getPolygonStatePolitical(string stateName, string [] locations)
        //{
        //    StateShapePolitical stateShape = new StateShapePolitical();
        //    stateShape.StateName = stateName;
        //    stateShape.Stroke = new SolidColorBrush(Color.FromArgb(100, 65, 177, 255));
        //    stateShape.StrokeThickness = 3;
        //    LocationCollection locations = parseCoordinatesLocation(loc);
        //    stateShape.Locations = locations;



        //    return stateShape;
        //}


        //public List<StateShape> getMapPolygonListElevemos()
        //{
        //    Dictionary<string, string[]> dictionary = new StateCoordinate().getDictionaryStates();

        //    foreach (KeyValuePair<string, string[]> entry in dictionary)
        //    {
        //        Elevemos++;
        //        StateShape stateToAdd = getPolygonState(entry);
        //        listStates.Add(stateToAdd);
        //    }
        //    Elevemos = 0;
        //    return listStates;
        //}

        //private StateShape getPolygonStateElevemos(KeyValuePair<string, string[]> entry)
        //{
        //    StateShape stateShape = new StateShape();

        //    stateShape.Title = entry.Key as string;
        //    string[] coordinates = entry.Value as string[];

        //    stateShape.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.White);
        //    stateShape.StrokeThickness = 1;
        //    stateShape.Opacity = 0;

        //    if (Elevemos % 3 == 0)
        //    {
        //        stateShape.Fill=new SolidColorBrush(Color.FromArgb(100,241,251,10));
        //    }
            
            
        //    //VERDE Color.FromArgb(150, 105, 177, 48)
        //    //Amarillo Color.FromArgb(100,241,251,10));
        //    //Rojo Color.FromArgb(100,251,10,10)
        //    //Gris Color.FromArgb(100,128,128,128)
        //    //Selected Azul Color.FromArgb(100,0,197,255)
        //    stateShape.Fill.Opacity = 1;

        //    LocationCollection locations = parseCoordinatesLocation(coordinates);
        //    stateShape.Locations = locations;

        //    return stateShape;
        //}

        private static LocationCollection parseCoordinatesLocation(string[] coordinates)
        {
            LocationCollection locationCollection = new LocationCollection();
            foreach (string value in coordinates)
            {
                string[] points = value.Split(',');
                foreach (string s in points)
                {
                    try
                    {
                        string cleans = s.TrimStart(' ').TrimEnd(' ');
                        locationCollection.Add(new Location(double.Parse(cleans.Split(' ')[1]), double.Parse(cleans.Split(' ')[0])));
                    }
                    catch { }
                }
            }

            return locationCollection;
        }

    }
}
