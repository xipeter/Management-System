<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format" 
xmlns:hl7="urn:hl7-org:v2xml">
	<xsl:template match="/">
		<html>
			<head>
				<title>东软LIS</title>
			</head>
			<body bgcolor="#E7EFEF">
				<xsl:apply-templates select="/hl7:ORU_R01/hl7:ORU_R01.PATIENT_RESULT"/>
			</body>
		</html>
	</xsl:template>
	
	<xsl:template match="/hl7:ORU_R01/hl7:ORU_R01.PATIENT_RESULT">
		<xsl:apply-templates select="hl7:ORU_R01.PATIENT/hl7:PID"/>
		<xsl:apply-templates select="hl7:ORU_R01.ORDER_OBSERVATION/hl7:OBR"/>
		<!-->_______________________________________________________________________________</-->
		<table border="0" cellpadding="0" cellspacing="0" align="center">
			<tr>
				<td colspan="5" height="1">
					<hr/>
				</td>
			</tr>
			<tr>
				<td>编码</td>
				<td>名称</td>
				<td>结果</td>
				<td>单位</td>
				<td>参考值</td>
			</tr>
			<tr>
				<td colspan="5" height="1">
					<hr/>
				</td>
			</tr>
			
			<xsl:apply-templates select="hl7:ORU_R01.ORDER_OBSERVATION/hl7:ORU_R01.OBSERVATION"/>
			<tr>
				<td colspan="5">
					<hr/>
				</td>
			</tr>
		</table>
		<p></p>
		<!-->_______________________________________________________________________________</-->
	</xsl:template>
	
	
	<!-->
		检验单信息格式
	</-->
	<xsl:template match="hl7:ORU_R01.PATIENT/hl7:PID">
		<table cellpadding="0" cellspacing="0" bgcolor="#C6DFDE">
			<tr>
				<td width="220">
					<font size="4">
						患者号:<xsl:value-of select="./hl7:PID.3/hl7:CX.1"/>
					</font>
				</td>
				<td width="140">
					<font size="4">
						姓名:<xsl:value-of select="./hl7:PID.5/hl7:XPN.1/hl7:FN.1"/><xsl:value-of select="./hl7:PID.5/hl7:XPN.2"/>
					</font>
				</td>
				<td width="100">
					<font size="4">
						性别:<xsl:value-of select="./hl7:PID.8"/>
					</font>
				</td>
				<td width="220">
					<font size="4">
						出生日期:<xsl:value-of select="./hl7:PID.7/hl7:TS.1"/>
					</font>
				</td>
			</tr>
		</table>
		
		<p/>

		

	</xsl:template>
	

<xsl:template match="hl7:ORU_R01.ORDER_OBSERVATION/hl7:OBR">
		<table bgcolor="#ffffcc" width="600" align="center">
			<tr>
				<td width="240">
				检验项目：<xsl:value-of select="./hl7:OBR.4/hl7:CE.2"/>
				</td>
				<td width="180">
				样本类型:<xsl:value-of select="./hl7:OBR.15/hl7:SPS.1/hl7:CE.2"/>
				</td>
				<td>
				检验日期:<xsl:value-of select="./hl7:OBR.6/hl7:TS.1"/>
				</td>
			</tr>
		</table>
</xsl:template>
	<!-->
	____________________________________________________________
		检验单结果格式
	____________________________________________________________
	</-->
	<xsl:template match="hl7:ORU_R01.ORDER_OBSERVATION/hl7:ORU_R01.OBSERVATION">
		<tr>
			<td width="80">
				<xsl:value-of select="./hl7:OBX/hl7:OBX.3/hl7:CE.1"/>
			</td>
			<td width="180">
				<xsl:value-of select="./hl7:OBX/hl7:OBX.3/hl7:CE.2"/>
			</td>
			<td width="100">
				<xsl:value-of select="./hl7:OBX/hl7:OBX.5"/>　<xsl:value-of select="./hl7:OBX/hl7:OBX.8"/>
			</td>
			<td width="100">
				<xsl:value-of select="./hl7:OBX/hl7:OBX.6/hl7:CE.1"/>
			</td>
			<td width="100">
				<xsl:value-of select="./hl7:OBX/hl7:OBX.7"/>
			</td>
		</tr>
	</xsl:template>
</xsl:stylesheet>
