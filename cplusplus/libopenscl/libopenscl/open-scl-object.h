/* -*- Mode: C; indent-tabs-mode: t; c-basic-offset: 4; tab-width: 4 -*- */
/*
 * libopenscl
 * Copyright (C) Daniel Espinosa Ortiz 2009 <esodan@gmail.com>
 * 
 * libopenscl is free software: you can redistribute it and/or modify it
 * under the terms of the GNU General Public License as published by the
 * Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * libopenscl is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 * See the GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License along
 * with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

#ifndef _OPEN_SCL_OBJECT_H_
#define _OPEN_SCL_OBJECT_H_

namespace OpenSCL 
{
	class Object
	{
	public:
		::IEC61850::SCL configuration;
		void IP(string ip);
		void AddLD(string name);
		void PublishGOOSE(string MAC, string gcb, string goid);
		void SuscribeGOOSE(GOOSE goose);

	protected:

	private:

	};
}

#endif // _OPEN_SCL_OBJECT_H_
