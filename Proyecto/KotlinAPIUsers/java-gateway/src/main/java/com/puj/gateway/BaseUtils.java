package com.puj.gateway;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UserDetails;

import java.net.Inet6Address;
import java.net.InetAddress;
import java.net.NetworkInterface;
import java.net.UnknownHostException;
import java.util.Enumeration;


public class BaseUtils {
    private static final Logger logger = LoggerFactory.getLogger(BaseUtils.class);

    public static String getCurrentUser() {
        String username = null;
        Object principal = SecurityContextHolder.getContext().getAuthentication().getPrincipal();

        if (principal instanceof UserDetails) {
            username = ((UserDetails)principal).getUsername();
        } else {
            username = principal.toString();
        }

        return username;
    }

    public static String getLocalIpv4() {
        InetAddress ip;
        try {
            ip = Inet6Address.getLocalHost();
            String localname = ip.getHostName();
            String localip = ip.getHostAddress();
            logger.debug("run server name" + localname +"server ip:"+ localip);
            return  localip;
        } catch (UnknownHostException e) {
            e.printStackTrace();
            logger.error("----get local ipv4 error------"+ e.getMessage());
        }
        return getLocalIp();
    }

    public static String getLocalIp() {
        StringBuffer sb = new StringBuffer();
        try {
            Enumeration<NetworkInterface> en = NetworkInterface.getNetworkInterfaces();
            while (en.hasMoreElements()) {
                NetworkInterface ni = (NetworkInterface) en.nextElement();
                Enumeration<InetAddress> enumInetAddr = ni.getInetAddresses();
                while (enumInetAddr.hasMoreElements()) {
                    InetAddress inetAddress = (InetAddress) enumInetAddr.nextElement();

                    if (!inetAddress.isLoopbackAddress() && !inetAddress.isLinkLocalAddress()
                            && inetAddress.isSiteLocalAddress()) {
                        sb.append(inetAddress.getHostAddress().toString());
                    }
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
            logger.error("----get local ip error------"+ e.getMessage());
        }
        return sb.toString();
    }
}