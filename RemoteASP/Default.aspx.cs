using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    [DllImport("user32", CharSet = CharSet.Auto)]
    static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32")]
    static extern IntPtr GetConsoleWindow();

    const UInt32 WM_APPCOMMAND = 0x0319;
    const UInt32 APPCOMMAND_VOLUME_DOWN = 9;
    const UInt32 APPCOMMAND_VOLUME_UP = 10;

    static void IncreaseVolume()
    {
        var cw = GetConsoleWindow();
        SendMessage(cw, WM_APPCOMMAND, cw, new IntPtr(APPCOMMAND_VOLUME_UP << 16));
        Console.WriteLine("16");
    }

    static void DecreaseVolume()
    {
        var cw = GetConsoleWindow();
        SendMessage(cw, WM_APPCOMMAND, cw, new IntPtr(APPCOMMAND_VOLUME_DOWN << 16));
        Console.WriteLine("-16");
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnVolumeUp_Click(object sender, EventArgs e)
    {
        Connect("127.0.0.1", "2");
    }

    protected void btnVolumeDown_Click(object sender, EventArgs e)
    {
        Connect("127.0.0.1", "1");
    }
    private void Connect(String server, String message)
    {
        try
        {
            // Create a TcpClient.
            // Note, for this client to work you need to have a TcpServer 
            // connected to the same address as specified by the server, port
            // combination.
            Int32 port = 13000;
            TcpClient client = new TcpClient(server, port);

            // Translate the passed message into ASCII and store it as a Byte array.
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

            // Get a client stream for reading and writing.
            //  Stream stream = client.GetStream();

            NetworkStream stream = client.GetStream();

            // Send the message to the connected TcpServer. 
            stream.Write(data, 0, data.Length);

            Console.WriteLine("Sent: {0}", message);

            // Receive the TcpServer.response.

            // Buffer to store the response bytes.
            data = new Byte[256];

            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);

            // Close everything.
            stream.Close();
            client.Close();
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException: {0}", e);
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }
    }
}