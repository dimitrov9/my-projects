using Karavas_Stock_Management.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karavas_Stock_Management
{       
    public abstract class SQLControl
    {
        #region Element Types and their Dimensions strings
        public static string[] ElementTypes = { "Frames", "Base Jack", "Head Jack", "Cross Braces", "Braces", "Connection Tube", "Beam", "Guard Rail", "Fixed Decks", "Trap Door Deck", "Metal Deck", "Diagonal Brace", "Side Bracket", "Tubes With Brace", "Stop", "Douple Coupler" };
        public static string[] FramesDimensions = {"0,75m x 1,00m","0,75m x 2,00m","1,20m x 1,20m", "1,33m x 1,00m", "1,33m x 2,00m", "1,80m x 1,20m", "2,00m x 1,00m", "2,00m x 1,20m","2,00m x 2,00m","2,20m x 1,20m", "2,40m x 1,20m", "0,85m x 1,00m al", "0,85m x 2,00m al", "1,33m x 1,00m al", "1,33m x 2,00m al", "1,40m x 1,00m al", "1,40m x 2,00m al" };
        public static string[] BaseJackDimensions = { "0,70m", "1,00m" };
        public static string[] HeadJackDimensions = { "K-11 0,70m", "K-11 1,00m", "K-17 1,00m", "K-22", };

        public static string[] CrossBraceDimensions = { "1,45m", "1,75m", "2,10m", "3,70m", "1,85m" };
        public static string[] BracesDimensions = { "2,00m", "2,50m", "3,00m", "4,00m", "6,00m", "1,00m" };
        public static string[] ConnectionTubeDimensions = { "1", "2" };
        public static string[] BeamDimensions = { "2,45m", "2,90m", "3,30m", "3,60m", "3,90m", "4,50m", "4,90m", "5,90m" };
        public static string[] GuardRailDimensions = { "3,16m x 0,53m", "3,00m x 0,53m", "2,50m x 0,53m", "2,00m x 0,53m", "1,50m x 0,53m", "1,25m x 0,53m", "1,00m x 0,53m" };
        public static string[] FixedDeckDimensions = { "2,50m x 0,61m", "2,50m x 0,31m", "2,00m x 0,61m", "2,00m x 0,31m", "1,50m x 0,61m", "1,50m x 0,31m", "1,25m x 0,61m", "1,00m x 0,61m", "1,25m x 0,31m" };
        public static string[] TrapDoorDeckDimension = { "2,50m x 0,61m" };
        public static string[] MetalDeckDimensions = { "2,50m x 0,30m", "3,00m x 0,30m", "3,16m x 0,30m", "2,00m x 0,30m", "1,50m x 0,30m", "1,25m x 0,30m", "1,00m x 0,30m", "3,00m x 0,50m", "2,50m x 0,50m", "2,00m x 0,50m", "1,85m x 0,30m", "1,85m x 0,50m" };
        public static string[] DiagonalBraceDimensions = { "3,65m", "3,10m", "2,50m", "1,90m", "1,70m" };
        public static string[] SideBracketDimensions = { "0,45m", "0,60m", "0,70m", "0,90m" };
        public static string[] TubesWithBraceDimensions = { "1,00m", "2,00m" };
        public static string[] StopDimensions = { "0,75m", "1,00m" };
        public static string[] DoubleCouplerDimension = { "0,90m" };
        #endregion

        public static string[][] TypesIndexAndDimensions = { FramesDimensions, BaseJackDimensions, HeadJackDimensions, CrossBraceDimensions, BracesDimensions, ConnectionTubeDimensions, BeamDimensions, GuardRailDimensions, FixedDeckDimensions, TrapDoorDeckDimension, MetalDeckDimensions, DiagonalBraceDimensions, SideBracketDimensions, TubesWithBraceDimensions, StopDimensions, DoubleCouplerDimension };
        public static Bitmap[] ImagesOfElementTypes = { Resources.Frame, Resources.Fixed_Deck, Resources.TRAPDOORDECK, Resources.GuardRail, Resources.Cevki, Resources.Diagonal_Brace, Resources.SideBracket, Resources.Tube_With_Brace, Resources.Base_Jack, Resources.Stop, Resources.Double_Coupler, Resources.Vilushki, Resources.Nogari, Resources.VkrsteniCevki, Resources.Spojnici, Resources.Gredi };
        public static string connectionString = Properties.Settings.Default.KaravasStockManagementAmazon;


        #region Most used queries
        public static string objectsWithLastStateQuery(bool Archived) {
            string query = @"Select * From Object as Obj
                                                        LEFT OUTER JOIN (Select Sum(MomentState) as TotalMomentState, ObjectID From State
	                                                            Where StateID IN (
		                                                            Select Max(StateID) from State
		                                                            Group By ObjectID,ElementID
		                                                            )
		                                                            Group By ObjectID) as ura
                                                        ON ura.ObjectID = Obj.ObjectId
                                                        Where Obj.ObjectID = 1 or Obj.Closed =  ";
            if (Archived)
            {
                return query + "1";
            }
            else
            {
                return query + "0";
            }
        } 

        public static string deleteObjectWithStates(string Objects) {

            string query = @"Select [StateID] as this,[StateID]+1 as nextt
                            into test
                            From [dbo].[State]
                            Where [ObjectID] IN ( @obj )

                            Delete From [dbo].[State] 
                            Where StateID IN (Select [StateID]
                            From [dbo].[State] 
                            Inner join test
                            on [StateID]=test.this or [StateID]=test.nextt)

                            Delete From [dbo].[Object]
                            Where [ObjectID] IN ( @obj )

                            drop table test";

            query = query.Replace("@obj", Objects);
            return query;
        } 

        public static string LatestElementTypesFromObject(int objectID)
        {
            return @"Select El.ElementTypesID, sum(st.MomentState) as TypeLastState
                    From State as st,Elements as El,(
                    Select st.ElementID,Max(st.StateID) as StateID
                    From State as st
                    Where st.ObjectID = " + objectID.ToString() +
                    @"Group By st.ElementID
                    ) as bah
                    Where st.StateID =bah.StateID and st.ElementID = El.ElementsID 
                    Group By El.ElementTypesID
                    ORDER BY El.ElementTypesID ASC";
        }
        public static string ElementTypeFromID(int ElementTypesID)
        {
            string query = @"Select ElementType From ElementTypes
                    Where ElementTypesID = " + ElementTypesID.ToString();

            return GetData(query).Rows[0][0].ToString();
        }

        public static string GetDimensions(string elementType)
        {
            return @"Select El.Dimension, El.ElementsID 
                    From Elements as El, ElementTypes as eTy
                    Where eTy.ElementTypesID = El.ElementTypesID and eTy.ElementType = '" + elementType + "';";

        }

        public static string GetDimensionsStates(int elementType,int objectID)
        {
            return @"Select St.ElementID,  El.Dimension,St.MomentState
                    From Elements as El,State as St
                    Where St.ElementID = El.ElementsID and St.StateID IN(
						Select Max(St.StateID)
						From State as St,Elements as El
						Where St.ObjectID = " + objectID.ToString() + " and El.ElementTypesID = " + elementType.ToString() + @" and St.ElementID=El.ElementsID
						Group By ObjectID,ElementID
					)
                    Order By St.MomentState Desc";
        }

        public static string GetDimensionsStates(int elementType, int objectID,string elementsID)
        {
            return @"Select St.ElementID,  El.Dimension,St.MomentState
                    From Elements as El,State as St
                    Where St.ElementID = El.ElementsID and St.StateID IN(
						Select Max(St.StateID)
						From State as St,Elements as El
						Where St.ObjectID = " + objectID.ToString() + " and El.ElementTypesID = " + elementType.ToString() + " and El.ElementsID IN (" + elementsID + ")" + @" and St.ElementID=El.ElementsID
						Group By ObjectID,ElementID
					)
                    Order By St.MomentState Desc";
        }

        public static int GetElementID(string elementType,string dimension)
        {
            string query = @"Select ElementsID 
                            From Elements as El, ElementTypes as eTy
                            Where El.ElementTypesID = eTy.ElementTypesID and eTy.ElementType = '" + elementType.Trim() + "' and El.Dimension = '" + dimension.Trim() + "'";
            return (int)GetData(query).Rows[0][0];
        }

        public static int GetLastState(int elementID,int objectID)
        {
            string query = @"Select MomentState
                            From State
                            Where StateID IN (
	                            Select Max(StateID)
	                            From State 
	                            Where ObjectID = " + objectID.ToString() + " and ElementID = " + elementID.ToString() +
                                "Group By ObjectID,ElementID)";

            DataTable bla = GetData(query);
            return bla.Rows.Count>0 ? (int)bla.Rows[0][0] : 0;
        }

        public static int GetLastSumState(int objectID)
        {
            string query = @"Select SUM(MomentState)
                            From State
                            Where StateID IN
                            (Select Max(StateID)
                            From State
                            Where ObjectID = "+ objectID.ToString() + @"
                            Group By ElementID)
                            Group By ObjectID";

            DataTable bla = GetData(query);
            return bla.Rows.Count > 0 ? (int)bla.Rows[0][0] : 0;
        }

                /// <summary>
        /// Which objects should be closed(archived)
        /// </summary>
        /// <param name="shouldClose">True to archive, false to activate</param>
        /// <param name="objects">String of the objects ready for query</param>
        /// <returns></returns>
        public static string SwitchedClosedOnObjects(bool shouldClose,string objects)
        {
            string query = @"UPDATE [dbo].[Object]
                            SET [Closed] = @cls
                            WHERE [ObjectId] IN ( @obj );";
            if (shouldClose)
            {
                query = query.Replace("@cls", "1");
            }
            else
            {
                query = query.Replace("@cls", "0");
            }
            return query.Replace("@obj", objects);
        }

        #endregion

        /// <summary>
        /// <para>Gets selected table from the connectionString</para>
        /// <para>- Can be null if error</para>
        /// </summary>
        /// <returns>
        /// DataTable containing the returned table 
        /// ** Can be null if error 
        /// </returns>
        /// 
        public static DataTable GetData(string query)
        {
            waitForm waitFrm = new waitForm();
            waitFrm.Show();
            waitFrm.Refresh();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    con.Open();
                    SqlDataAdapter da;
                    DataTable dT;

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        // create data adapter
                        da = new SqlDataAdapter(command);
                        // this will query your database and return the result to your datatable
                        dT = new DataTable();
                        da.Fill(dT);
                    }

                    con.Close();
                    da.Dispose();
                    return dT;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
            finally
            {
                waitFrm.Close();
            }
            //Application.Exit();
            return null;
        }

        /// <summary>
        /// Used for deleting rows depends on the query inputed
        /// </summary>
        /// <param name="query">The SQL code where the delete command is allowed</param>
        /// <param name="connectionString">The Connection string for the main dataset</param>
        public static void ExecuteQuery(string query)
        {
            waitForm waitFrm = new waitForm();
            waitFrm.Show();
            waitFrm.Refresh();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    con.Open();
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
            finally
            {
                waitFrm.Close();
            }
        }

        public static bool LoginAttepmt(string username,string password)
        {
            waitForm waitFrm = new waitForm();
            waitFrm.Show();
            waitFrm.Refresh();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "Select * from [dbo].[Users] where [Username] = '@username' and [Password] = '@password'";
                    query = query.Replace("@username", username);
                    query = query.Replace("@password", password);

                    con.Open();
                    SqlDataAdapter da;
                    DataTable dT;
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        // create data adapter
                        da = new SqlDataAdapter(command);
                        // this will query your database and return the result to your datatable
                        dT = new DataTable();
                        da.Fill(dT);
                    }
                    con.Close();

                    if (dT.Rows.Count > 0)
                    {
                        da.Dispose();
                        dT.Dispose();
                        return true;
                    }
                    else
                    {
                        da.Dispose();
                        dT.Dispose();
                        MessageBox.Show("Incorrect username or passowrd!");
                        return false;
                    }
                }
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
                return false;
            }
            finally
            {
                waitFrm.Close();
            }
        }

    }
}