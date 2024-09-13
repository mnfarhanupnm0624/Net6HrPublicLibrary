using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6HrPublicLibrary.PublicShared
{
    public class JanaBarcode
    {
        public static string MtdJanaBarcode(string fn_textin)
        {
            //var log = NLog.LogManager.GetCurrentClassLogger();
            //log.Info("MtdJanaBarcode fn_textin ~ " + fn_textin);
            Encoding ascii = Encoding.ASCII;
            string _barcode = "";
            // MEMBUANG SPACE DAN UNSUR LAIN SELAIN DARI NOMBOR DAN ABJAD
            string ls_t1 = fn_textin.Trim();
            int li_1 = ls_t1.Length;
            int na = 0;
            string ls_str = "";
            string ls_text = "";
            string ls_bar = "";
            string TEMP_TEXT = "";
            int d1 = 0;
            //log.Info("MtdJanaBarcode li_1 ~  " + li_1  + " ls_t1 ~ " + ls_t1 + "   na - " + na);
            do
            {
                ls_str = ls_t1.Substring(na, 1);
                //log.Info("MtdJanaBarcode na ~  " + na + " ls_str ~ " + ls_str + "   ls_text - " + ls_text);
                if (ls_str != " ")
                {
                    if (NumberHelper.IsNumeric(ls_str) || MtdCheckSmallabc(ls_str) || MtdCheckUpperabc(ls_str))
                    {
                        ls_text = ls_text + ls_str;
                    }
                }
                na = na + 1;
            } while (na < li_1);

            //log.Info("MtdJanaBarcode ls_text ~ " + ls_text);
            // messagebox ("Intake","Data Trim =>" + ls_text + "<=")
            // response.write(Asc("B") & "<br />")

            // MEMBUAT SENARAI NOMBOR BARCODE AWAL 13 DIJIT

            ls_t1 = ls_text.Trim();
            li_1 = ls_t1.Length;
            ls_bar = "";
            //log.Info("MtdJanaBarcode ls_t1 ~  " + ls_t1 + " li_1 ~ " + li_1 );
            if (NumberHelper.IsNumeric(ls_t1))
            {
                //log.Info("MtdJanaBarcode NumberHelper.IsNumeric(ls_t1) ~  " + ls_t1 );
            }
            else
            {
                //log.Info("MtdJanaBarcode NumberHelper.IsNumeric(ls_t1) ~ false " + ls_t1);
                for (int ii = 0; ii < li_1; ii++)
                {
                    ls_t1 = ls_t1.Trim();
                    d1 = ls_t1.Length;
                    int nd1 = d1;
                    int dt1 = 0;
                    na = 0;
                    //log.Info("MtdJanaBarcode for ii - " + ii + "   ls_t1 -" + ls_t1 + "  d1 - " + d1);
                    bool do_while = true;
                    do
                    {
                        ls_str = ls_t1.Substring(na, 1);    // Mid(ls_t1, na, 1)
                        int _x = NumberHelper.ToIntiger(ascii_value(ls_str));
                        //log.Info("MtdJanaBarcode do do_while - " + do_while + "   ls_str -" + ls_str + "  _x - " + _x);
                        if (_x > 64)
                        {
                            int li_asc = _x - 64;
                            TEMP_TEXT = li_asc.ToString();
                            //log.Info("MtdJanaBarcode ( _x > 64)  li_asc -" + li_asc + "  TEMP_TEXT - " + TEMP_TEXT + "   na " + na + " d1 " + d1);
                            if (na == d1)
                            {
                                ls_t1 = ls_t1.Substring(1, d1 - 1) + TEMP_TEXT.Trim();
                                ls_t1 = ls_t1.Trim();
                                //Exit Sub
                                //GoTo go_rimba
                                do_while = false;
                            }
                            else
                            {
                                //log.Info("MtdJanaBarcode (na != d1)  ls_t1 -" + ls_t1 + "  TEMP_TEXT - " + TEMP_TEXT + "   na " + na + " d1 " + d1);
                                if (na == 0)
                                {
                                    int _p = d1 - (na + 1);
                                    int _m1 = na + 1;
                                    //log.Info("MtdJanaBarcode (na == 0)  ls_t1 -" + ls_t1 + "  _m1 - " + _m1 + " _p " + _p);
                                    ls_t1 = TEMP_TEXT.Trim() + ls_t1.Substring(_m1, _p);
                                    //log.Info("MtdJanaBarcode (hasil)  ls_t1 -" + ls_t1);
                                }
                                else
                                {
                                    int _p = d1 - (na + 1);
                                    int _m1 = na + 1;
                                    //log.Info("MtdJanaBarcode (na == 0)  ls_t1 -" + ls_t1 + "  _m1 - " + _m1 + " _p " + _p);
                                    ls_t1 = ls_t1.Substring(0, na) + TEMP_TEXT.Trim() + ls_t1.Substring(_m1, _p);
                                }
                                //log.Info("MtdJanaBarcode (after)  ls_t1 -" + ls_t1 + "  TEMP_TEXT - " + TEMP_TEXT + "   na " + na + " d1 " + d1);
                                ls_t1 = ls_t1.Trim();
                                nd1 = ls_t1.Length;
                                na = na + 1;
                                dt1 = nd1 - d1;
                                if (dt1 > 0)
                                {
                                    na = na + dt1;
                                    d1 = nd1;
                                }
                            }
                        }
                        else
                        {
                            na = na + 1;
                            if (na >= d1)
                            {
                                do_while = false;
                            }
                        }
                    } while (do_while);
                }
            }

            ls_text = ls_t1.Trim();
            d1 = ls_text.Length;
            //log.Info("MtdJanaBarcode ls_text.Length ~ " + d1 + " ls_text ~ " + ls_text);
            //'response.write(ls_text & "<br />")
            if (d1 < 12)
            {
                if (d1 == 1) { ls_str = "00000000000"; }
                else if (d1 == 2) { ls_str = "0000000000"; }
                else if (d1 == 3) { ls_str = "000000000"; }
                else if (d1 == 4) { ls_str = "00000000"; }
                else if (d1 == 5) { ls_str = "0000000"; }
                else if (d1 == 6) { ls_str = "000000"; }
                else if (d1 == 7) { ls_str = "00000"; }
                else if (d1 == 8) { ls_str = "0000"; }
                else if (d1 == 9) { ls_str = "000"; }
                else if (d1 == 10) { ls_str = "00"; }
                else if (d1 == 11) { ls_str = "0"; }
                ls_bar = ("2" + ls_str + ls_text).PadLeft(13);    //  , 13)
            }
            else
            {
                ls_bar = ("2" + ls_text).PadLeft(13);
            }
            //log.Info("MtdJanaBarcode ls_bar ~ " + ls_bar);

            //'MENCARI KOD PENYUDAH UNTUK NOMBOR BARCODE AWAL 13 DIJIT
            li_1 = ls_bar.Length;
            int formula_1 = 1;
            int count_i = 0;
            int formula_3 = 0;
            int formula_2 = 0;
            do
            {
                ls_str = ls_bar.Substring(count_i, 1);
                if (formula_1 == 1)
                {
                    formula_1 = 2;
                }
                else
                {
                    formula_1 = 1;
                }

                formula_2 = NumberHelper.ToIntiger(ls_str) * formula_1;
                if (formula_2 > 9)
                {
                    if (formula_2 == 10) { formula_2 = 1; }
                    else if (formula_2 == 12) { formula_2 = 3; }
                    else if (formula_2 == 14) { formula_2 = 5; }
                    else if (formula_2 == 16) { formula_2 = 7; }
                    else if (formula_2 == 18) { formula_2 = 9; }
                }
                formula_3 = formula_3 + formula_2;
                count_i = count_i + 1;
            } while (count_i < li_1);
            //log.Info("MtdJanaBarcode formula_3 ~ " + formula_3);
            double formula_4 = formula_3 / 10;
            //log.Info("MtdJanaBarcode formula_4 ~ " + formula_4);
            double formula_5 = Math.Round(formula_4, MidpointRounding.AwayFromZero);
            //log.Info("MtdJanaBarcode formula_5 ~ " + formula_5);
            if (formula_5 < formula_4) formula_5 = formula_5 + 1;
            formula_4 = formula_5 * 10;
            double formula_6 = formula_4 - formula_3;
            //log.Info("MtdJanaBarcode formula_6 ~ " + formula_6);
            if (formula_6 < 0) formula_6 = formula_6 * (-1);
            TEMP_TEXT = formula_6.ToString();
            //log.Info("MtdJanaBarcode TEMP_TEXT ~ " + TEMP_TEXT);
            _barcode = ls_bar + TEMP_TEXT;
            //log.Info("MtdJanaBarcode _barcode ~ " + _barcode);
            return _barcode;
        }

        private static string ascii_value(string _char)
        {

            if (_char == " ") { return "032"; }
            else if (_char == "!") { return "033"; }
            else if (_char == "\"") { return "034"; }
            else if (_char == "#") { return "035"; }
            else if (_char == "$") { return "036"; }
            else if (_char == "%") { return "037"; }
            else if (_char == "&") { return "038"; }
            else if (_char == "'") { return "039"; }
            else if (_char == "(") { return "040"; }
            else if (_char == ")") { return "041"; }
            else if (_char == "*") { return "042"; }
            else if (_char == "+") { return "043"; }
            else if (_char == ",") { return "044"; }
            else if (_char == "-") { return "045"; }
            else if (_char == ".") { return "046"; }
            else if (_char == "/") { return "047"; }
            else if (_char == "0") { return "048"; }
            else if (_char == "1") { return "049"; }
            else if (_char == "2") { return "050"; }
            else if (_char == "3") { return "051"; }
            else if (_char == "4") { return "052"; }
            else if (_char == "5") { return "053"; }
            else if (_char == "6") { return "054"; }
            else if (_char == "7") { return "055"; }
            else if (_char == "8") { return "056"; }
            else if (_char == "9") { return "057"; }
            else if (_char == ":") { return "058"; }
            else if (_char == ";") { return "059"; }
            else if (_char == "<") { return "060"; }
            else if (_char == "=") { return "061"; }
            else if (_char == ">") { return "062"; }
            else if (_char == "?") { return "063"; }
            else if (_char == "@") { return "064"; }
            else if (_char == "A") { return "065"; }
            else if (_char == "B") { return "066"; }
            else if (_char == "C") { return "067"; }
            else if (_char == "D") { return "068"; }
            else if (_char == "E") { return "069"; }
            else if (_char == "F") { return "070"; }
            else if (_char == "G") { return "071"; }
            else if (_char == "H") { return "072"; }
            else if (_char == "I") { return "073"; }
            else if (_char == "J") { return "074"; }
            else if (_char == "K") { return "075"; }
            else if (_char == "L") { return "076"; }
            else if (_char == "M") { return "077"; }
            else if (_char == "N") { return "078"; }
            else if (_char == "O") { return "079"; }
            else if (_char == "P") { return "080"; }
            else if (_char == "Q") { return "081"; }
            else if (_char == "R") { return "082"; }
            else if (_char == "S") { return "083"; }
            else if (_char == "T") { return "084"; }
            else if (_char == "U") { return "085"; }
            else if (_char == "V") { return "086"; }
            else if (_char == "W") { return "087"; }
            else if (_char == "X") { return "088"; }
            else if (_char == "Y") { return "089"; }
            else if (_char == "Z") { return "090"; }
            else if (_char == "[") { return "091"; }
            else if (_char == "\\") { return "092"; }
            else if (_char == "]") { return "093"; }
            else if (_char == "^") { return "094"; }
            else if (_char == "_") { return "095"; }
            else if (_char == "'") { return "096"; }
            else if (_char == "a") { return "097"; }
            else if (_char == "b") { return "098"; }
            else if (_char == "c") { return "099"; }
            else if (_char == "d") { return "100"; }
            else if (_char == "e") { return "101"; }
            else if (_char == "f") { return "102"; }
            else if (_char == "g") { return "103"; }
            else if (_char == "h") { return "104"; }
            else if (_char == "i") { return "105"; }
            else if (_char == "j") { return "106"; }
            else if (_char == "k") { return "107"; }
            else if (_char == "l") { return "108"; }
            else if (_char == "m") { return "109"; }
            else if (_char == "n") { return "110"; }
            else if (_char == "o") { return "111"; }
            else if (_char == "p") { return "112"; }
            else if (_char == "q") { return "113"; }
            else if (_char == "r") { return "114"; }
            else if (_char == "s") { return "115"; }
            else if (_char == "t") { return "116"; }
            else if (_char == "u") { return "117"; }
            else if (_char == "v") { return "118"; }
            else if (_char == "w") { return "119"; }
            else if (_char == "x") { return "120"; }
            else if (_char == "y") { return "121"; }
            else if (_char == "z") { return "122"; }
            else { return "0"; }
        }

        private static bool MtdCheckUpperabc(string _value)
        {
            Boolean _return = false;
            string[] stringArray = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int pos = Array.IndexOf(stringArray, _value);
            if (pos > -1)
            {
                _return = true;
            }
            return _return;
        }

        private static bool MtdCheckSmallabc(string _value)
        {
            Boolean _return = false;
            string[] stringArray = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            int pos = Array.IndexOf(stringArray, _value);
            if (pos > -1)
            {
                _return = true;
            }
            return _return;
        }

    }
}
